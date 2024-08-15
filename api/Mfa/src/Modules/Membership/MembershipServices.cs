using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Mappers;
using Mfa.Enums;

namespace Mfa.Services;
public class MembershipServices: IMembershipServices {
    private readonly IMembershipRepository _membershipRepository;

    public MembershipServices(IMembershipRepository membershipRepository) {
        _membershipRepository = membershipRepository;
    }

    public async Task CreateMembership(CreateMembershipRequest dto)
    {
        if (dto.Members != null) {
            if (dto.MembershipType == MembershipTypes.Single && dto.Members.Count() > 1) throw new Exception("Single memberships can only have one member.");
        }

        await _membershipRepository.CreateMembership(dto.ToMembership());
    }

    public Task DeleteMembership(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<GetMembershipResponse> GetMembershipById(int id)
    {
        var membership = await _membershipRepository.GetMembershipById(id);

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