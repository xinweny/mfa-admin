namespace Mfa.Modules.Address;

public interface IAddressService {
    Task<AddressDto> GetAddress(int id);
    Task<IEnumerable<AddressDto>> GetAddresses();
}