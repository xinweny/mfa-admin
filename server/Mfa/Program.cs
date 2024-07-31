using Microsoft.EntityFrameworkCore;

using Mfa.Database;

namespace Mfa;

public class Program {
    public static void Main(string[] args) {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<MfaDbContext>(options => {
            options.UseNpgsql(builder.Configuration.GetConnectionString("postgresdb"));
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        var app = builder.Build();

        app.UseHttpsRedirection();
        
        app.MapControllers();

        app.Run();
    }
}
