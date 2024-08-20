using Mfa.Modules.Membership;

namespace Mfa.Modules.Address;

public class MembershipAddressService : IMembershipAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMembershipRepository _membershipRepository;

    public MembershipAddressService(
        IAddressRepository addressRepository,
        IMembershipRepository membershipRepository
    ) {
        _addressRepository = addressRepository;
        _membershipRepository = membershipRepository;
    }

    public async Task CreateAddress(int membershipId, CreateAddressRequest req) {
        var membership = await _membershipRepository.GetMembershipById(membershipId)
            ?? throw new KeyNotFoundException();

        if (membership.Address != null) throw new Exception("Membership already has an address.");

        var address = req.ToAddress();

        await _addressRepository.CreateAddress(address);

        await _membershipRepository.UpdateMembershipAddressId(membership, address.Id);
    }
    
    public async Task DeleteAddress(int membershipId)
    {
        var membership = await _membershipRepository.GetMembershipById(membershipId)
            ?? throw new KeyNotFoundException();

        var address = membership.Address ?? throw new KeyNotFoundException();
    
        await _membershipRepository.UpdateMembershipAddressId(membership, null);

        await _addressRepository.DeleteAddress(address);
    }

    public async Task UpdateAddress(int membershipId, UpdateAddressRequest req)
    {
        var membership = await _membershipRepository.GetMembershipById(membershipId)
            ?? throw new KeyNotFoundException();

        var address = membership.Address ?? throw new KeyNotFoundException();

        await _addressRepository.UpdateAddress(address, req);
    }
}