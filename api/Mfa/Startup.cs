using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Mfa.Database;
using Mfa.Middleware;

using Mfa.Modules.Address;
using Mfa.Modules.Auth;
using Mfa.Modules.Due;
using Mfa.Modules.Membership;
using Mfa.Modules.Member;

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
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => {
            options.SwaggerDoc("v1", new OpenApiInfo {
                Version = "v1",
                Title = "MFA Member API",
                Description = "An ASP.NET Core Web API for managing members and memberships of the Mississauga Friendship Association."
            });
        });

        services.AddAuthModule(Configuration);
        services.AddAddressModule();
        services.AddDueModule();
        services.AddMembershipModule();
        services.AddMemberModule();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
        else {
            app.UseHsts();
        }

        app.UseStatusCodePages();
        app.UseExceptionHandler();
        app.UseHttpsRedirection();
        
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<IPWhitelistMiddleware>();
        app.UseEndpoints(endpoints => {
            if (env.IsDevelopment()) {
                endpoints.MapControllers().AllowAnonymous();
            } else {
                endpoints.MapControllers();
            }
        });
    }
}