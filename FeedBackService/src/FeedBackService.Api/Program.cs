using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, reloadOnChange: true);
            if (currentEnvironment?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
            {
                configBuilder.AddJsonFile($"appsettings.{currentEnvironment}.json", optional: false);
            }
            /****pour le log debut***/
            IConfigurationRoot config = configBuilder.Build();
            LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
            Logger logger = LogManager.GetCurrentClassLogger();
            /****pour le log fin***/

            try
            {
                /****pour le log debut***/
                logger.Info($"{ApiConstants.FriendlyServiceName} starts running ...");
                /****pour le log fin***/
                CreateHostBuilder(args).Build().Run();
                /****pour le log debut***/
                logger.Info($"{ApiConstants.FriendlyServiceName} is stopped");
                /****pour le log fin***/
            }
            catch (Exception exception)
            {
                /****pour le log debut***/
                logger.Error(exception);
                /****pour le log fin***/
                throw;
            }
            finally
            {
                /****pour le log debut***/
                LogManager.Shutdown();
                /****pour le log fin***/
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                }
                ).UseNLog();

    }
}
