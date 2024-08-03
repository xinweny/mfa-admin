using Microsoft.EntityFrameworkCore;

using Mfa.Database;
using Mfa.Interfaces;
using Mfa.Services;
using Mfa.Middleware;

namespace Mfa;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<MfaDbContext>(options => {
            options.UseNpgsql(builder.Configuration.GetConnectionString("postgresdb"));
        });

        builder.Services.AddExceptionHandler<ExceptionHandlerMiddleware>();
        builder.Services.AddProblemDetails();
        builder.Services.AddLogging();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        RegisterServices(builder);

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.MapControllers();

        app.UseStatusCodePages();
        app.UseExceptionHandler();



        app.Run();
    }

    public static void RegisterServices(WebApplicationBuilder builder) {
        builder.Services.AddScoped<IUserServices, UserServices>();
    }
}
