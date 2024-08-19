using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    
    public AddressService(IAddressRepository addressRepository) {
        _addressRepository = addressRepository;
    }

    public Task<AddressDto> GetAddress(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AddressDto>> GetAddresses()
    {
        throw new NotImplementedException();
    }
}