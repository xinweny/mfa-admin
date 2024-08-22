namespace MfaApi.Modules.Address;

public interface IAddressService {
    Task<AddressDto> GetAddress(Guid id);
    Task<IEnumerable<AddressDto>> GetAddresses();
    Task CreateAddress(Guid membershipId, CreateAddressRequest req);
    Task UpdateAddress(Guid membershipId, UpdateAddressRequest req);
    Task DeleteAddress(Guid membershipId);
}