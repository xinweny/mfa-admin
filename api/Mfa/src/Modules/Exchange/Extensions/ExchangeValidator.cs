using FluentValidation;

using Mfa.Common.Constants;

namespace Mfa.Modules.Exchange;

public class ExchangeValidator: AbstractValidator<ExchangeModel> {
    public ExchangeValidator() {
        RuleFor(e => e.ExchangeType)
            .NotNull()
            .WithMessage("Exchange type is required.")
            .IsInEnum()
            .WithMessage("Invalid exchange type.");

        RuleFor(e => e.Year)
            .NotNull()
            .WithMessage("Year is required.")
            .GreaterThanOrEqualTo(MfaConstants.MfaFoundingYear)
            .WithMessage($"Year must be at least {MfaConstants.MfaFoundingYear}.");

        RuleFor(e => e.MemberId)
            .NotNull()
            .WithMessage("Member ID is required.");
    }
}