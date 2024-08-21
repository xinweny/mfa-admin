namespace Mfa.Modules.Membership;

public class MembershipService: IMembershipService {
    private readonly IMembershipRepository _membershipRepository;

    public MembershipService(IMembershipRepository membershipRepository) {
        _membershipRepository = membershipRepository;
    }

    public async Task CreateMembership(CreateMembershipRequest req) {
        await _membershipRepository.CreateMembership(req.ToMembership());
    }

    public async Task DeleteMembership(int id) {
        var membership = await _membershipRepository.GetMembershipById(id)
            ?? throw new KeyNotFoundException("Membership not found.");

        await _membershipRepository.DeleteMembership(membership);
    }

    public async Task<GetMembershipResponse> GetMembershipById(int id) {
        var membership = await _membershipRepository.GetMembershipById(id)
            ?? throw new KeyNotFoundException("Membership not found.");

        return membership.ToGetMembershipResponse();
    }

    public async Task<IEnumerable<GetMembershipsResponse>> GetMemberships() {
        var memberships = await _membershipRepository.GetMemberships();

        return memberships.Select(m => m.ToGetMembershipsResponse());
    }

    public async Task UpdateMembership(int id, UpdateMembershipRequest req) {
        var membership = await _membershipRepository.GetMembershipById(id)
            ?? throw new KeyNotFoundException("Membership not found.");

        await _membershipRepository.UpdateMembership(membership, req);
    }
}