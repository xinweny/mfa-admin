using FluentValidation;

namespace MfaApi.Modules.BoardMember;

public static class BoardMemberModule {
    public static void AddBoardMemberModule(this IServiceCollection services) {
        services.AddScoped<IBoardMemberRepository, BoardMemberRepository>();
        services.AddScoped<IBoardMemberService, BoardMemberService>();
        services.AddScoped<IValidator<BoardMemberModel>, BoardMemberValidator>();
    }
}