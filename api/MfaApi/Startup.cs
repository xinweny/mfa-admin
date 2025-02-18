using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using MfaApi.Database;
using MfaApi.Middleware;
using MfaApi.Modules;
using MfaApi.Modules.Auth;

namespace MfaApi;

public class Startup {
    public IConfiguration Configuration { get; }
    private IWebHostEnvironment Environment { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env) {
        Configuration = configuration;
        Environment = env;
    }

    public void ConfigureServices(IServiceCollection services) {
        services.AddDbContext<MfaDbContext>(options => {
            options.UseNpgsql(Configuration.GetConnectionString("postgresdb"));
        });

        services.AddCors(options => {
            options.AddDefaultPolicy(policy => {
                policy 
                    .WithOrigins(Configuration["ClientUrl"]!);
            });
        });

        services.AddExceptionHandler<ExceptionHandlerMiddleware>();
        services.AddProblemDetails();
        services.AddLogging();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => {
            options.SwaggerDoc("v1", new OpenApiInfo {
                Version = "v1",
                Title = "MFA Member API",
                Description = "An ASP.NET Core Web API for managing members and memberships of the Mississauga Friendship Association."
            });
        });

        services.AddAuthModule(Configuration);

        services.AddControllers();
        
        services.AddMfaApiModules();
    }

    public void Configure(IApplicationBuilder app) {
        if (Environment.IsDevelopment()) {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        } else {
            app.UseHsts();
        }

        app.UseStatusCodePages();
        app.UseExceptionHandler();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints => {
            endpoints
                .MapControllers()
                .RequireAuthorization();
        });
    }
}