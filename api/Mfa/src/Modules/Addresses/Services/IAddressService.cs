namespace Mfa.Addresses;

public interface IAddressService {
    Task<AddressDto> GetAddress(int id);
    Task<IEnumerable<AddressDto>> GetAddresses();
}