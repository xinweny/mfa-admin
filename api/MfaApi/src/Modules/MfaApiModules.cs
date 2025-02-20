namespace MfaApi.Modules;

using Address;
using Auth;
using Due;
using Membership;
using Member;
using Exchange;
using BoardMember;

public static class MfaApiModules {
    public static void AddMfaApiModules(this IServiceCollection services) {        
        services.AddAddressModule();
        services.AddDueModule();
        services.AddMembershipModule();
        services.AddMemberModule();
        services.AddExchangeModule();
        services.AddBoardMemberModule();
    }
}