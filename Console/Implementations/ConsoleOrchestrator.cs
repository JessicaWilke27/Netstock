using Common.Enums;
using Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace NetstockConsole
{
    internal class ConsoleOrchestrator : IOrchestrator

    {
        private ILogger _logger;
        private IService _service;
        private IScheduler _scheduler;
        public ConsoleOrchestrator(ILogger logger, IService service, Func<IScheduler> scheduler)
        {
            this._logger = logger;
            this._service = service;
            this._scheduler = scheduler.Invoke();
        }

        public async Task RunOrchestratorAsync()
        {
            try
            {
                this._logger.Log(LogRecordType.info, "_____________________Starting StockSyncOrchestrator_____________________");
                while (true)
                {
                    await this._service.StartServiceAsync();
                    this._logger.Log(LogRecordType.info, "_______________Waiting for scheduler to trigger execution .........._______________");
                    await this._scheduler.NotifyNextExecution();
                    this._logger.Log(LogRecordType.info, "Scheduler triggered service execution ..........");
                }
            }
            catch (Exception ex)
            {
                this._logger.Log(LogRecordType.error, ex.Message);
                return;
            }
        }
    }
}
