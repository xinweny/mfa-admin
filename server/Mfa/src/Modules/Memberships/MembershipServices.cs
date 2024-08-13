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

    public async Task<int> CreateMembership(CreateMembershipRequest dto)
    {
        var membership = await _membershipRepository.CreateMembership(dto.ToMembership());

        return membership.Id;
    }

    public Task DeleteMembership(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<GetMembershipResponse> GetMembershipById(int id)
    {
        Membership membership = await _membershipRepository.GetMembershipById(id);

        return membership.ToGetMembershipResponse();
    }

    public Task<IEnumerable<GetMembershipsResponse>> GetMemberships()
    {
        throw new NotImplementedException();
    }

    public Task UpdateMembership(int id, UpdateMembershipRequest dto)
    {
        throw new NotImplementedException();
    }
}