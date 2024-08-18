using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Mappers;
using Mfa.Enums;
using Microsoft.IdentityModel.Tokens;

namespace Mfa.Services;
public class MembershipService: IMembershipService {
    private readonly IMembershipRepository _membershipRepository;

    public MembershipService(IMembershipRepository membershipRepository) {
        _membershipRepository = membershipRepository;
    }

    public async Task CreateMembership(CreateMembershipRequest dto)
    {
        if (dto.Members.IsNullOrEmpty()) {
            throw new Exception("Memberships must contain at least one member.");
        }

        if (dto.MembershipType == MembershipTypes.Single && dto.Members.Count() != 1) {
            throw new Exception("Single memberships can only have one member.");
        }

        await _membershipRepository.CreateMembership(dto.ToMembership());
    }

    public async Task DeleteMembership(int id)
    {
        var membership = await _membershipRepository.GetMembershipById(id);

        await _membershipRepository.DeleteMembership(membership);
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

    public async Task UpdateMembership(int id, UpdateMembershipRequest dto)
    {
        var membership = await _membershipRepository.GetMembershipById(id);

        await _membershipRepository.UpdateMembership(membership, dto);
    }
}