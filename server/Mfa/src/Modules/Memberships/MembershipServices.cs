using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Mappers;
using Mfa.Enums;

namespace Mfa.Services;
public class MembershipServices: IMembershipServices {
    private readonly IMembershipRepository _membershipRepository;
    private readonly IMemberRepository _memberRepository;

    public MembershipServices(IMembershipRepository membershipRepository, IMemberRepository memberRepository) {
        _membershipRepository = membershipRepository;
        _memberRepository = memberRepository;
    }

    public async Task CreateMembership(CreateMembershipRequest dto)
    {
        if (dto.Members != null) {
            if (dto.MembershipType == MembershipTypes.Single && dto.Members.Count() > 1) throw new Exception("Single memberships can only have one member.");
        }

        var membership = await _membershipRepository.CreateMembership(dto.ToMembership());

        if (dto.Members != null) await _memberRepository.CreateMembers(dto.Members.Select(dto => dto.ToMember(membership.Id)));
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