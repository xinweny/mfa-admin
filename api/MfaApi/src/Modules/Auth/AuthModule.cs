using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace MfaApi.Modules.Auth;

using Authorization;

public static class AuthModule {
    public static void AddAuthModule(this IServiceCollection services, IConfiguration Configuration) {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                options.Authority = $"https://{Configuration["Auth0:Domain"]}";
                options.Audience = Configuration["Auth0:Audience"];
            });
        services.AddAuthorization();

        services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
    }
}