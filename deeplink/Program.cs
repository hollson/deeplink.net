using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Deeplink.Repositories;
using Deeplink.Services;
using System;


namespace Deeplink
{
    public class Program
    {
        // Host(宿主机)构建器
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        //使用Microsoft.Extensions.Hosting.Host作为默认构造器
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            // 指定Host配置项，包含服务映射等
            webBuilder.UseStartup<Startup>();
        });

        // 构建Host，并启动Host
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Initializes db.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<FoodDbContext>();
                    var dbInitializer = services.GetRequiredService<ISeedDataService>();
                    dbInitializer.Initialize(context).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }
    }
}
