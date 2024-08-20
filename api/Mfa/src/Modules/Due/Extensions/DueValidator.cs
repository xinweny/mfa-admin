using FluentValidation;

using Mfa.Common.Constants;

namespace Mfa.Modules.Due;

public class DueValidator: AbstractValidator<DueModel> {
    public DueValidator() {
        RuleFor(d => d.Year)
            .NotNull()
            .WithMessage("Year is required.")
            .GreaterThanOrEqualTo(MfaConstants.MfaFoundingYear)
            .WithMessage($"Year must be at least ${MfaConstants.MfaFoundingYear}.");

        RuleFor(d => d.PaymentMethod)
            .NotNull()
            .WithMessage("Payment method is required.")
            .IsInEnum()
            .WithMessage("Invalid payment method.");

        RuleFor(d => d.AmountPaid)
            .NotNull()
            .WithMessage("Amount paid is required.")
            .GreaterThan(0)
            .WithMessage("Amount paid must be greater than 0.");

        RuleFor(d => d.PaymentDate)
            .NotNull()
            .WithMessage("Payment date is required.");

        RuleFor(d => d.MembershipId)
            .NotNull()
            .WithMessage("Membership ID is required.");
    }
}