using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MfaApi.Modules.Auth;

public static class AuthModule {
    public static void AddAuthModule(this IServiceCollection services, IConfiguration Configuration) {
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options => {
                options.Authority = Configuration.GetValue<string>("AUTH0_AUTHORITY") ?? Configuration["Auth0:Authority"];
                options.Audience = Configuration.GetValue<string>("AUTH0_AUDIENCE")?? Configuration["Auth0:Audience"];
            });

        services.AddAuthorization();
    }
}