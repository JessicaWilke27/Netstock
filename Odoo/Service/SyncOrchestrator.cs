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
                IRepository repoLocationData = _getRepoFunc(typeof(LocationDataRepository).Name);
                IRepository repoSupplierData = _getRepoFunc(typeof(SupplierDataRepository).Name);
                IRepository repoPoLineData = _getRepoFunc(typeof(PoLineDataRepository).Name);
                IRepository repoPoHistData = _getRepoFunc(typeof(PoHistDataRepository).Name);

                var taskList = new List<Task>();
                taskList.Add(Task.Run(() => repoMasterData.GetData<MasterModel>(connectionStringAuthenticated, $"{this._outputDir}master.csv", new ProcessDataDelegate<MasterModel>(CallbackImplementations.ProcessData))));
                taskList.Add(Task.Run(() => repoLocationData.GetData<LocationModel>(connectionStringAuthenticated, $"{this._outputDir}location.csv", new ProcessDataDelegate<LocationModel>(CallbackImplementations.ProcessData))));
                taskList.Add(Task.Run(() => repoSupplierData.GetData<SupplierModel>(connectionStringAuthenticated, $"{this._outputDir}supplier.csv", new ProcessDataDelegate<SupplierModel>(CallbackImplementations.ProcessData))));
                taskList.Add(Task.Run(() => repoPoLineData.GetData<PoLineModel>(connectionStringAuthenticated, $"{this._outputDir}po.csv", new ProcessDataDelegate<PoLineModel>(CallbackImplementations.ProcessData))));
                taskList.Add(Task.Run(() => repoPoHistData.GetData<PoHistModel>(connectionStringAuthenticated, $"{this._outputDir}pohist.csv", new ProcessDataDelegate<PoHistModel>(CallbackImplementations.ProcessData))));

                Task.WaitAll(taskList.ToArray());
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
