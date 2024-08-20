using FluentValidation;

namespace Mfa.Modules.Member;

public class MemberValidator: AbstractValidator<MemberModel> {
    public MemberValidator() {
        RuleFor(m => m.FirstName)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(m => m.LastName)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(m => m.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(320);

        RuleFor(m => m.PhoneNumber)
            .Matches(@"^\d{10}$");

        RuleFor(m => m.MembershipId)
            .NotNull();
    }
}