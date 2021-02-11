using System;
using System.IO;
using Amazon.Runtime;
using Coolblue.Utilities.MonitoringEvents;
using Coolblue.Utilities.MonitoringEvents.Aws.Lambda.Datadog;
using Coolblue.Utilities.MonitoringEvents.SimpleInjector;
using Coolblue.Utilities.Resilience;
using Gimme.Core;
using Gimme.Oracle.Adapter;
using Gimme.SecretManagement.Adapter;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using SimpleInjector;

namespace Gimme.Host.Lambda
{
    public static class Bootstrapper
    {

        private static IConfigurationRoot GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("parameters.json", true)
                .AddJsonFile("development.parameters.json", false)
                .AddEnvironmentVariables()
                .Build();

            return config;
        }

        internal static LambdaSettings GetLambdaSettings()
        {
            return GetConfiguration().Get<LambdaSettings>();
        }

        public static Container CreateDefaultApplication(LambdaSettings lambdaSettings)
        {
            var container = new Container();
            container.Options.PropertySelectionBehavior = new MonitoringEventsPropertySelectionBehavior();
            RegisterTypes(container, lambdaSettings);
            return container;
        }
        private static void RegisterTypes(Container container, LambdaSettings settings)
        {
            var log = new LoggerConfiguration()
                              .Enrich.FromLogContext()
                              .MinimumLevel.Verbose()
                              .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                              .WriteTo.Console(new JsonFormatter())
                              .CreateLogger();
            var monitoringEvents = CreateMonitoringEvents(log);
            var secretManagementAdapter = SecretManagementAdapter.GetSecretManagementAdapter(settings.Environment);
        
            container.RegisterInstance(settings);
            container.RegisterInstance<IOracleSettings>(settings);
            //settings.OracleUserName = secretManagementAdapter.DecryptString(settings.OracleUserName).Result;
            //settings.OraclePassword = secretManagementAdapter.DecryptString(settings.OraclePassword).Result;
            settings.OracleUserName = "devvanessa";
            settings.OraclePassword = "mordor";
            container.RegisterInstance(monitoringEvents);
            var persistenceAdapter = SetupPersistence(settings, monitoringEvents);
            persistenceAdapter.Register(container);
        }
        private static PersistenceAdapter SetupPersistence(LambdaSettings settings, MonitoringEvents monitoringEvents)
        {
            try
            {
                var persistenceSetting = new PersistenceAdapterSettings(settings.FullConnectionString) {
                    OracleResilience = settings.OracleResilience
                };
                return new PersistenceAdapter(persistenceSetting, monitoringEvents);
            }
            catch
            {
                Console.WriteLine("Error while attempting to connect to Oracle");
                throw;
            }
        }

        private static MonitoringEvents CreateMonitoringEvents(ILogger logger)
        {
            return new MonitoringEvents(logger, new AwsLambdaDatadogMetrics());
        }
    }
}
