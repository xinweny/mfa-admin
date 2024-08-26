using FluentValidation;

namespace MfaApi.Modules.Address;

public class AddressValidator: AbstractValidator<AddressModel> {
    public AddressValidator() {
        RuleFor(a => a.Line1)
            .NotEmpty()
                .WithMessage("Line1 is required.")
            .MaximumLength(256)
                .WithMessage("Line1 cannot exceed 256 characters.");

        RuleFor(a => a.Line2)
            .MaximumLength(256)
                .WithMessage("Line2 cannot exceed 256 characters.");

        RuleFor(a => a.City)
            .NotEmpty()
                .WithMessage("City is required.")
            .MaximumLength(64)
                .WithMessage("City name cannot exceed 64 characters.");

        RuleFor(a => a.PostalCode)
            .NotEmpty()
                .WithMessage("Postal code is required.")
            .MaximumLength(32)
                .WithMessage("Postal code length cannot exceed 32 characters.");
            
        RuleFor(a => a.Province)
            .IsInEnum()
                .WithMessage("Invalid province.");
    }
}