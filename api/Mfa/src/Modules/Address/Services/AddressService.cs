namespace Mfa.Modules.Address;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository) {
        _addressRepository = addressRepository;
    }

    public async Task<AddressDto> GetAddress(int id)
    {
        var address = await _addressRepository.GetAddressById(id)
            ?? throw new KeyNotFoundException("Address not found.");

        return address.ToAddressDto();
    }

    public async Task<IEnumerable<AddressDto>> GetAddresses()
    {
        var address = await _addressRepository.GetAddresses();

        return address.Select(a => a.ToAddressDto());
    }
}