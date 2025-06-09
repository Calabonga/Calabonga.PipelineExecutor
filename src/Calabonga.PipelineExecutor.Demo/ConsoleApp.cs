using DotNetEnv;
using DotNetEnv.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Calabonga.PipelineExecutor.Demo
{
    /// <summary>
    /// Create Container for Console App
    /// </summary>
    public static class ConsoleApp
    {
        /// <summary>
        /// Creates container <see cref="ServiceCollection"/>
        /// </summary>
        /// <returns></returns>
        public static ServiceProvider CreateContainer(Action<IServiceCollection>? additionalServices = null)
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: false)
                .AddDotNetEnv(".env", LoadOptions.TraversePath())
                .Build();

            var logger = new LoggerConfiguration().MinimumLevel
#if DEBUG
                .Debug()
#else
            .Warning()
#endif
                .WriteTo.Console()
                .CreateLogger();

            services.AddLogging(x => x.AddSerilog(logger));

            services.Configure<AppSettings>(x => configuration.GetSection(nameof(AppSettings)).Bind(x));

            additionalServices?.Invoke(services);

            return services.BuildServiceProvider();
        }
    }
}
