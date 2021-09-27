using Common.Interfaces;
using Models;
using Odoo.Callbacks;
using Odoo.Interfaces;
using Odoo.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Odoo.Callbacks.CallbackDelegates;

namespace Odoo
{
    public class SyncOrchestrator : IOrchestrator
    {
        private IConfig _config;
        private IAuthenticator _authenticator;
        private Func<string, IRepository> _getRepoFunc;
        string _outputDir;
        public SyncOrchestrator(IConfig config, IAuthenticator authenticator, Func<string, IRepository> getRepoFunc)
        {
            this._config = config;
            this._authenticator = authenticator;
            this._getRepoFunc = getRepoFunc;
            this._outputDir = this._config.GetOuputDir();
        }

        public async Task RunOrchestratorAsync()
        {
            try
            {
                var connectionStringStart = this._config.GetConnectionString();
                var connectionStringAuthenticated = this._authenticator.Authenticate(connectionStringStart);

                IRepository repoMasterData = _getRepoFunc(typeof(MasterDataRepository).Name);

                var taskList = new List<Task>();
                taskList.Add(Task.Run(() => repoMasterData.GetData<MasterModel>(connectionStringAuthenticated, $"{this._outputDir}master.csv", new ProcessDataDelegate<MasterModel>(CallbackImplementations.ProcessData))));
                Task.WaitAll(taskList.ToArray());
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
