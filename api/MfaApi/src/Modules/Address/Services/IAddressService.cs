namespace MfaApi.Modules.Address;

public interface IAddressService {
    Task<AddressDto> GetAddress(int id);
    Task<IEnumerable<AddressDto>> GetAddresses();
    Task CreateAddress(int membershipId, CreateAddressRequest req);
    Task UpdateAddress(int membershipId, UpdateAddressRequest req);
    Task DeleteAddress(int membershipId);
}