namespace Mfa.Addresses;

public static class AddressDependencyModule {
    public static void AddAddressModule(this IServiceCollection services) {
        services.AddScoped<IAddressRepository, AddressRepository>();
    }
}