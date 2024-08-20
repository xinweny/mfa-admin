using FluentValidation;

namespace Mfa.Modules.Exchange;

public class ExchangeValidator: AbstractValidator<ExchangeModel> {
    public ExchangeValidator() {
        RuleFor(e => e.ExchangeType)
            .NotNull()
            .IsInEnum();
        RuleFor(e => e.Year)
            .NotNull()
            .GreaterThanOrEqualTo(1993);
        RuleFor(e => e.MemberId)
            .NotNull();
    }
}