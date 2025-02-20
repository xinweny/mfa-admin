using FluentValidation;

namespace MfaApi.Modules.Address;

public static class AddressModule {
    public static void AddAddressModule(this IServiceCollection services) {
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IValidator<AddressModel>, AddressValidator>();
    }
}