using Mfa.Models;
using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Mappers;

namespace Mfa.Services;
public class MembershipServices: IMembershipServices {
    private readonly IMembershipRepository _membershipRepository;

    public MembershipServices(IMembershipRepository membershipRepository) {
        _membershipRepository = membershipRepository;
    }

    public Task CreateMembership(CreateMembershipRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMembership(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<GetMembershipResponseDto> GetMembershipById(int id)
    {
        Membership membership = await _membershipRepository.GetMembershipById(id);

        return membership.ToGetMembershipResponseDto();
    }

    public Task<IEnumerable<GetMembershipsResponseDto>> GetMemberships()
    {
        throw new NotImplementedException();
    }

    public Task UpdateMembership(int id, UpdateMembershipRequestDto dto)
    {
        throw new NotImplementedException();
    }
}