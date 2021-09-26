using Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Common.Enums;

namespace Odoo
{
    public class SyncService : IService
    {
        ILogger _logger;
        IOrchestrator _orchestrator;
        bool _isInit = false;
        public SyncService(ILogger logger)
        {
            this._logger = logger;
            this._isInit = this.Init();
        }

        public async Task StartServiceAsync()
        {
            var result = await Task.Run(() =>
            {
                if (!this._isInit)
                {
                    this._logger.Log(LogRecordType.error, "Initialization failure in Odoo Service ..........");
                    return false;
                }
                this._orchestrator.RunOrchestratorAsync();
                return true;
            });
            return;
        }

        private bool Init()
        {
            bool initResult = true;
            var serviceProvider = Startup.GetInstance().Init(this._logger);
            if (serviceProvider == null)
            {
                initResult = false;
                this._logger.Log(Common.Enums.LogRecordType.error, "Error in initialization of SyncService.");
                return initResult;
            }
            this._orchestrator = serviceProvider.GetService<IOrchestrator>();
            return initResult;
        }
    }
}
