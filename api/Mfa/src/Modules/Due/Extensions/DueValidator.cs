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
            .IsInEnum()
                .WithMessage("Invalid payment method.");

        RuleFor(d => d.AmountPaid)
            .Cascade(CascadeMode.Stop)
            .NotNull()
                .WithMessage("Amount paid is required.")
            .GreaterThan(0)
                .WithMessage("Amount paid must be greater than 0.")
            .Must(amountPaid => amountPaid == MfaConstants.SingleMembershipCost)
                .When(d => d.Membership?.MembershipType == Membership.MembershipType.Single, ApplyConditionTo.CurrentValidator)
                .WithMessage($"Single membership cost is ${MfaConstants.SingleMembershipCost}.")
            .Must(amountPaid => amountPaid == MfaConstants.FamilyMembershipCost)
                .When(d => d.Membership?.MembershipType == Membership.MembershipType.Family, ApplyConditionTo.CurrentValidator)
                .WithMessage($"Family membership cost is ${MfaConstants.FamilyMembershipCost}.");

        RuleFor(d => d.PaymentDate)
            .NotNull()
                .WithMessage("Payment date is required.");

        RuleFor(d => d.MembershipId)
            .NotNull()
                .WithMessage("Membership ID is required.");
    }
}