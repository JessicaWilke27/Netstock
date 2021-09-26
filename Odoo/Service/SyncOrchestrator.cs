using Common.Interfaces;
using Odoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Odoo
{
    public class SyncOrchestrator : IOrchestrator
    {
        private IConfig _config;
        private IAuthenticator _authenticator;
        private ILogger _logger;
        public SyncOrchestrator(ILogger logger, IConfig config, IAuthenticator authenticator)
        {
            _logger = logger;
            this._config = config;
            this._authenticator = authenticator;
        }

        public async Task RunOrchestratorAsync()
        {
            try
            {
                var connectionStringStart = this._config.GetConnectionString();
                var connectionStringAuthenticated = this._authenticator.Authenticate(connectionStringStart);

                var taskList = new List<Task>();
                taskList.Add(Task.Run(() => _logger.Log(Common.Enums.LogRecordType.info,"In Odoo Orchestrator")));

                Task.WaitAll(taskList.ToArray());
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
