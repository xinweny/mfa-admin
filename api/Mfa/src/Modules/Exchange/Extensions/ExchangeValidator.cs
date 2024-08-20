using FluentValidation;

using Mfa.Common.Constants;

namespace Mfa.Modules.Exchange;

public class ExchangeValidator: AbstractValidator<ExchangeModel> {
    public ExchangeValidator() {
        RuleFor(e => e.ExchangeType)
            .NotNull()
            .IsInEnum();

        RuleFor(e => e.Year)
            .NotNull()
            .GreaterThanOrEqualTo(Constants.MfaFoundingYear);

        RuleFor(e => e.MemberId)
            .NotNull();
            
    }
}