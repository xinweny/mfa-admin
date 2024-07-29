using Mfa.Database;
using Microsoft.EntityFrameworkCore;

namespace Mfa;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<MfaContext>(options => {
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
