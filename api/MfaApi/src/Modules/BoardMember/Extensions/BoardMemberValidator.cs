using FluentValidation;

using MfaApi.Common.Constants;

namespace MfaApi.Modules.BoardMember;

public class BoardMemberValidator: AbstractValidator<BoardMemberModel> {
    public BoardMemberValidator() {
        RuleFor(b => b.BoardPosition)
            .IsInEnum()
                .WithMessage("Invalid board position.");
        
        RuleFor(b => b.StartDate)
            .NotNull()
                .WithMessage("Start date is required.")
            .Must(startDate => startDate.Year >= MfaConstants.MfaFoundingYear)
                .WithMessage($"Start year must be at least {MfaConstants.MfaFoundingYear}.")
            .Must((b, startDate) => startDate < b.EndDate)
                .When(b => b.EndDate != null)
                .WithMessage("Start date cannot exceed the end date.");
        
        RuleFor(b => b.EndDate)
            .Must((b, endDate) => endDate > b.StartDate)
                .When(b => b.EndDate != null)
                .WithMessage("End date must be greater than the start date.");

        RuleFor(b => b.MemberId)
            .NotNull()
                .WithMessage("Member ID is required.");
    }
}