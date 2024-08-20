namespace Mfa.Modules.Address;

public interface IAddressRepository {
    Task<IEnumerable<AddressModel>> GetAddresses();
    Task<AddressModel?> GetAddressById(int id);
    Task CreateAddress(AddressModel address);
    Task UpdateAddress(AddressModel address, UpdateAddressRequest req);
    Task DeleteAddress(AddressModel address);
}