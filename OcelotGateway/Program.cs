using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace OcelotGateway
{
    public class Program
    {
        const string configurationDirectory = "Configuration";
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContent, config) =>
                {
                    config.AddJsonFile(Path.Combine(configurationDirectory, "appsettings.json"));
                    config.AddJsonFile(Path.Combine(configurationDirectory, "ocelot.json"));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
