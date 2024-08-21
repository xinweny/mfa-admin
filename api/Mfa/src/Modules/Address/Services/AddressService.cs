namespace Mfa.Modules.Address;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository) {
        _addressRepository = addressRepository;
    }

    public async Task<AddressDto> GetAddress(int id) {
        var address = await _addressRepository.GetAddressById(id);

        return address.ToAddressDto();
    }

    public async Task<IEnumerable<AddressDto>> GetAddresses() {
        var address = await _addressRepository.GetAddresses();

        return address.Select(a => a.ToAddressDto());
    }

    public async Task CreateAddress(int membershipId, CreateAddressRequest req) {
        await _addressRepository.CreateAddress(membershipId, req.ToAddress());
    }
    
    public async Task DeleteAddress(int membershipId) {
        await _addressRepository.DeleteAddress(membershipId);
    }

    public async Task UpdateAddress(int membershipId, UpdateAddressRequest req) {
        await _addressRepository.UpdateAddress(membershipId, req);
    }
}