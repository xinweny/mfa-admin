using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IAddressService {
    Task<AddressDto> GetAddress(int id);
    Task<IEnumerable<AddressDto>> GetAddresses();
}