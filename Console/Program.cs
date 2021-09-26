using System;
using Microsoft.Extensions.DependencyInjection;
using Common.Interfaces;

namespace NetstockConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup startup = Startup.GetInstance();
            var serviceProvider = startup.Init();
            if(serviceProvider == null)
            {
                Console.WriteLine("Error in initialization. Application will exit.");
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
                return;
            }

            IOrchestrator stockSyncOrchestrator = serviceProvider.GetService<IOrchestrator>();
            stockSyncOrchestrator.RunOrchestratorAsync().Wait();
        }
    }
}
