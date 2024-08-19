using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;

using Mfa.Database;
using Mfa.Middleware;

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

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                options.Authority = $"https://{Configuration["Auth0:Domain"]}";
                options.Audience = Configuration["Auth0:Audience"];
            });
        services.AddAuthorization(); // TODO: add scopes

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

        RegisterDependencies(services);
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

    private static void RegisterDependencies(IServiceCollection services) {
        services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

        // Repositories
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IMembershipRepository, MembershipRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IDueRepository, DueRepository>();

        // Services
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IMembershipService, MembershipService>();
        services.AddScoped<IMembershipAddressService, MembershipAddressService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IDueService, DueService>();

        // Validators
        services.AddScoped<IValidator<Member>, MemberValidator>();
    }
}