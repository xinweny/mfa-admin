using FluentValidation;

namespace Mfa.Modules.Membership;

public class MembershipValidator: AbstractValidator<MembershipModel> {
    public MembershipValidator() {
        RuleFor(m => m.MembershipType)
            .NotNull()
            .IsInEnum();
    }
}