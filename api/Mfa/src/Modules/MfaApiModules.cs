namespace Mfa.Modules;

using Address;
using Auth;
using Due;
using Membership;
using Member;

public static class MfaApiModules {
    public static void AddMfaApiModules(this IServiceCollection services, IConfiguration Configuration) {
        services.AddAuthModule(Configuration);
        services.AddAddressModule();
        services.AddDueModule();
        services.AddMembershipModule();
        services.AddMemberModule();
    }
}