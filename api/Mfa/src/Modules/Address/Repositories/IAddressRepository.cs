namespace Mfa.Modules.Address;

public interface IAddressRepository {
    Task<IEnumerable<AddressModel>> GetAddresses();
    Task<AddressModel> GetAddressById(int id);
    Task CreateAddress(int membershipId, AddressModel address);
    Task UpdateAddress(int membershipId, UpdateAddressRequest req);
    Task DeleteAddress(int membershipId);
}