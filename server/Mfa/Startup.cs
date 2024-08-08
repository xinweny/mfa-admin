using Microsoft.EntityFrameworkCore;

using Mfa.Data;
using Mfa.Middleware;
using Mfa.Interfaces;
using Mfa.Repositories;
using Mfa.Services;

namespace Mfa;

public class Startup {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {
        services.AddControllers();
        services.AddDbContext<MfaDbContext>(options => {
            options.UseNpgsql(Configuration.GetConnectionString("postgresdb"));
        });

        services.AddExceptionHandler<ExceptionHandlerMiddleware>();
        services.AddProblemDetails();
        services.AddLogging();

        services.AddEndpointsApiExplorer();
        services.AddDatabaseDeveloperPageExceptionFilter();

        RegisterDependencies(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }
        else {
            app.UseHsts();
        }

        app.UseStatusCodePages();
        app.UseExceptionHandler();
        app.UseHttpsRedirection();
        
        app.UseRouting();
        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }

    private static void RegisterDependencies(IServiceCollection services) {
        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<IUserServices, UserServices>();
    }
}