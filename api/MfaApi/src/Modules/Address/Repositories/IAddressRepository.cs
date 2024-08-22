namespace MfaApi.Modules.Address;

public interface IAddressRepository {
    Task<IEnumerable<AddressModel>> GetAddresses();
    Task<AddressModel> GetAddressById(Guid id);
    Task CreateAddress(Guid membershipId, AddressModel address);
    Task UpdateAddress(Guid membershipId, UpdateAddressRequest req);
    Task DeleteAddress(Guid membershipId);
}