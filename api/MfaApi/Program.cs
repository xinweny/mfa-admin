using MfaApi.Database;
using Microsoft.EntityFrameworkCore;

namespace MfaApi;

public class Program {
    public static void Main(string[] args) {
        var host = CreateHostBuilder(args).Build();

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development) {
            using (var scope = host.Services.CreateScope()) {
                var db = scope.ServiceProvider.GetRequiredService<MfaDbContext>();
                db.Database.Migrate();
            }
        }
        
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureAppConfiguration(configBuilder => {
                configBuilder.AddEnvironmentVariables();
            });
    }
}
