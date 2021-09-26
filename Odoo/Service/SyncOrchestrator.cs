using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Odoo
{
    public class SyncOrchestrator : IOrchestrator
    {
        private ILogger _logger { get; }
        public SyncOrchestrator(ILogger logger)
        {
            _logger = logger;
        }


        public async Task RunOrchestratorAsync()
        {
            try
            {
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
