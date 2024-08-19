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

    public async Task CreateMembership(CreateMembershipRequest req)
    {
        if (req.Members.IsNullOrEmpty()) {
            throw new Exception("Memberships must contain at least one member.");
        }

        if (req.MembershipType == MembershipTypes.Single && req.Members.Count() != 1) {
            throw new Exception("Single memberships can only have one member.");
        }

        await _membershipRepository.CreateMembership(req.ToMembership());
    }

    public async Task DeleteMembership(int id)
    {
        var membership = await _membershipRepository.GetMembershipById(id)
            ?? throw new KeyNotFoundException();

        await _membershipRepository.DeleteMembership(membership);
    }

    public async Task<GetMembershipResponse> GetMembershipById(int id)
    {
        var membership = await _membershipRepository.GetMembershipById(id)
            ?? throw new KeyNotFoundException();

        return membership.ToGetMembershipResponse();
    }

    public async Task<IEnumerable<GetMembershipsResponse>> GetMemberships()
    {
        var memberships = await _membershipRepository.GetMemberships();

        return memberships.Select(m => m.ToGetMembershipsResponse());
    }

    public async Task UpdateMembership(int id, UpdateMembershipRequest req)
    {
        var membership = await _membershipRepository.GetMembershipById(id)
            ?? throw new KeyNotFoundException();

        await _membershipRepository.UpdateMembership(membership, req);
    }
}