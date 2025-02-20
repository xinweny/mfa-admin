using FluentValidation;

namespace MfaApi.Modules.Member;

public static class MemberModule {
    public static void AddMemberModule(this IServiceCollection services) {
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IMemberSummaryService, MemberSummaryService>();
        services.AddScoped<IValidator<MemberModel>, MemberValidator>();
    }
}