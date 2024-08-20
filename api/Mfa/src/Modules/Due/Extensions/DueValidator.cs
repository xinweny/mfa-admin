using FluentValidation;

using Mfa.Common.Constants;

namespace Mfa.Modules.Due;

public class DueValidator: AbstractValidator<DueModel> {
    public DueValidator() {
        RuleFor(d => d.Year)
            .NotNull()
            .GreaterThanOrEqualTo(Constants.MfaFoundingYear)
            .LessThanOrEqualTo(DateTime.UtcNow.Year);

        RuleFor(d => d.PaymentMethod)
            .NotNull()
            .IsInEnum();

        RuleFor(d => d.AmountPaid)
            .NotNull()
            .GreaterThan(0);

        RuleFor(d => d.PaymentDate)
            .NotNull();

        RuleFor(d => d.MembershipId)
            .NotNull();
    }
}