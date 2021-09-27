using Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Odoo.Interfaces;
using Odoo.Repositories;
using System;

namespace Odoo
{
    public class Startup
    {
        private static Startup _startup;
        public static Startup GetInstance()
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

        public ServiceProvider Init(ILogger logger)
        {
            ServiceProvider serviceProvider = null;
            try
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<ILogger>(logger);
                serviceCollection.AddSingleton<IConfig, Config>();
                serviceCollection.AddSingleton<IAuthenticator, Authenticator>();
                serviceCollection.AddSingleton<IOrchestrator, SyncOrchestrator>();
                serviceCollection.AddScoped<IRepository, MasterDataRepository>();
                serviceCollection.AddScoped<IRepository, LocationDataRepository>();
                serviceCollection.AddScoped<IRepository, SupplierDataRepository>();
                serviceCollection.AddScoped<IRepository, PoLineDataRepository>();
                serviceCollection.AddScoped<IRepository, PoHistDataRepository>();
                serviceCollection.AddSingleton<RepositoryFactory, RepositoryFactory>();
                serviceCollection.AddTransient<Func<string, IRepository>>
                (serviceProvider => new Func<string, IRepository>
                    ((repoKey) =>
                    {
                        return serviceProvider.GetService<RepositoryFactory>().GetRepo(repoKey);
                    }
                    )
                );

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
