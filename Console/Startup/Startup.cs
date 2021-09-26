using Common.Enums;
using Common.Interfaces;
using Common.Logging;
using Common.Scheduling;
using Microsoft.Extensions.DependencyInjection;
using Odoo;
using System;

namespace NetstockConsole
{
    internal class Startup
    {

        private static Startup _startup;
        internal static Startup GetInstance()
        {
            if (_startup == null)
            {
                _startup = new Startup();
            }
            return _startup;
        }
        private Startup()
        {
        }

        internal ServiceProvider Init()
        {
            ServiceProvider serviceProvider = null;
            try
            {
                LogLevel logLevel = LoggingHelper.GetLoggingLevel();
                string schedulerTypeAsString = SchedulerHelper.GetSchedulerTypeAsString();

                var serviceCollection = new ServiceCollection();
                serviceCollection.AddLogging();
                serviceCollection.AddSingleton<IService, SyncService>();
                serviceCollection.AddSingleton<ILogger>(x => new ConsoleLogger(logLevel));
                serviceCollection.AddSingleton<IScheduler, InMinutesScheduler>();
                serviceCollection.AddScoped<IScheduler, InMinutesScheduler>();
                serviceCollection.AddScoped<IScheduler, InHoursScheduler>();
                serviceCollection.AddScoped<IScheduler, InDaysScheduler>();
                serviceCollection.AddSingleton<SchedulerFactory, SchedulerFactory>();
                serviceCollection.AddTransient<Func<IScheduler>>
                (serviceProvider => new Func<IScheduler>
                    (() =>
                    {
                        return serviceProvider.GetService<SchedulerFactory>().GetScheduler(schedulerTypeAsString);
                    }
                    )
                );
                serviceCollection.AddSingleton<IOrchestrator, ConsoleOrchestrator>();
                serviceProvider = serviceCollection.BuildServiceProvider();
            }
            catch (Exception ex)
            {
                serviceProvider = null;
            }
            return serviceProvider;
        }

    }
}
