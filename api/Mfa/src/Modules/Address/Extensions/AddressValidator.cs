using FluentValidation;

namespace Mfa.Modules.Address;

public class AddressValidator: AbstractValidator<AddressModel> {
    public AddressValidator() {
        RuleFor(a => a.Line1)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(a => a.Line2)
            .MaximumLength(256);

        RuleFor(a => a.Line3)
            .MaximumLength(256);

        RuleFor(a => a.City)
            .NotEmpty()
            .MaximumLength(64);

        RuleFor(a => a.PostalCode)
            .NotEmpty()
            .MaximumLength(32);
            
        RuleFor(a => a.Province)
            .NotEmpty()
            .IsInEnum();
    }
}