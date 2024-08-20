using FluentValidation;

namespace Mfa.Modules.Membership;

public static class MembershipModule {
    public static void AddMembershipModule(this IServiceCollection services) {
        services.AddScoped<IMembershipRepository, MembershipRepository>();
        services.AddScoped<IMembershipService, MembershipService>();
        services.AddScoped<IValidator<MembershipModel>, MembershipValidator>();
    }
}