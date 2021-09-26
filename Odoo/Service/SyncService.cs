using Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Common.Enums;

namespace Odoo
{
    public class SyncService : IService
    {
        private ILogger _logger;
        private IOrchestrator _orchestrator;
        public SyncService(ILogger logger)
        {
            _logger = logger;
            _orchestrator = new SyncOrchestrator(_logger);
        }

        public async Task StartServiceAsync()
        {
            var result = await Task.Run(() =>
            {
                _logger.Log(LogRecordType.info, "Kicking off orchestrator in service ..........");
                this._orchestrator.RunOrchestratorAsync();
                return true;
            });
            return;
        }
    }
}
