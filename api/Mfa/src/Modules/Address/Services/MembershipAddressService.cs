using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Mappers;

namespace Mfa.Services;

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

    public async Task CreateAddress(int membershipId, CreateAddressRequest dto) {
        var membership = await _membershipRepository.GetMembershipById(membershipId)
            ?? throw new KeyNotFoundException();

        if (membership.Address != null) throw new Exception("Membership already has an address.");

        var address = await _addressRepository.CreateAddress(dto.ToAddress());

        await _membershipRepository.UpdateMembership(membership, new UpdateMembershipRequest {
            AddressId = address.Id,
        });
    }
    
    public async Task DeleteAddress(int membershipId)
    {
        var membership = await _membershipRepository.GetMembershipById(membershipId)
            ?? throw new KeyNotFoundException();

        var address = membership.Address ?? throw new KeyNotFoundException();
    
        await _membershipRepository.UpdateMembership(membership, new UpdateMembershipRequest {
            AddressId = null,
        });

        await _addressRepository.DeleteAddress(address);
    }

    public async Task UpdateAddress(int membershipId, UpdateAddressRequest dto)
    {
        var membership = await _membershipRepository.GetMembershipById(membershipId)
            ?? throw new KeyNotFoundException();

        var address = membership.Address ?? throw new KeyNotFoundException();

        await _addressRepository.UpdateAddress(address, dto);
    }
}