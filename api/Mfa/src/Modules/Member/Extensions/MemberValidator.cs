using FluentValidation;

using Mfa.Common.Constants;

namespace Mfa.Modules.Member;

public class MemberValidator: AbstractValidator<MemberModel> {
    public MemberValidator() {
        RuleFor(m => m.FirstName)
            .NotEmpty()
                .WithMessage("First name is required.")
            .MaximumLength(256)
                .WithMessage("First name cannot exceed 256 characters.");

        RuleFor(m => m.LastName)
            .NotEmpty()
                .WithMessage("Last name is required.")
            .MaximumLength(256)
                .WithMessage("Last name cannot exceed 256 characters.");

        RuleFor(m => m.Email)
            .NotEmpty()
                .WithMessage("Email is required.")
            .EmailAddress()
                .WithMessage("Invalid email.")
            .MaximumLength(320)
                .WithMessage("Email cannot exceed 320 characters.");

        RuleFor(m => m.PhoneNumber)
            .Matches(@"^\d{10}$")
                .WithMessage("Invalid phone number.");
        
        RuleFor(m => m.JoinedDate)
            .Must(joinedDate => joinedDate?.Year >= MfaConstants.MfaFoundingYear)
                .When(m => m.JoinedDate != null)
                .WithMessage($"Joined date year must be at least {MfaConstants.MfaFoundingYear}.");

        RuleFor(m => m.MembershipId)
            .NotNull()
                .WithMessage("Membership ID is required.");
    }
}