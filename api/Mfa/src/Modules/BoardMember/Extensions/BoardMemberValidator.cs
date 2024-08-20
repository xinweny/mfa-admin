using FluentValidation;

using Mfa.Common.Constants;

namespace Mfa.Modules.BoardMember;

public class BoardMemberValidator: AbstractValidator<BoardMemberModel> {
    public BoardMemberValidator() {
        RuleFor(b => b.BoardPosition)
            .NotNull()
            .IsInEnum();
        
        RuleFor(b => b.StartDate)
            .NotNull()
            .Must(b => b.Year >= Constants.MfaFoundingYear)
            .Must((b, startDate) => b.EndDate == null || startDate < b.EndDate);
        
        RuleFor(b => b.EndDate)
            .Must((b, endDate) => endDate > b.StartDate);

        RuleFor(b => b.MemberId)
            .NotNull();
    }
}