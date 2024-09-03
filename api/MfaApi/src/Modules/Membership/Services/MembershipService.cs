using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Membership;

public class MembershipService: IMembershipService {
    private readonly IMembershipRepository _membershipRepository;

    public MembershipService(IMembershipRepository membershipRepository) {
        _membershipRepository = membershipRepository;
    }

    public async Task CreateMembership(CreateMembershipRequest req) {
        await _membershipRepository.CreateMembership(req.ToMembership());
    }

    public async Task DeleteMembership(Guid id) {
        var membership = await _membershipRepository.GetMembershipById(id);

        await _membershipRepository.DeleteMembership(membership);
    }

    public async Task<GetMembershipResponse> GetMembershipById(Guid id) {
        var membership = await _membershipRepository.GetMembershipById(id);

        return membership.ToGetMembershipResponse();
    }

    public async Task<IEnumerable<GetMembershipsResponse>> GetMemberships(GetMembershipsRequest req, PaginationMetadata metadata) {
        var query = _membershipRepository.GetMembershipsQuery(req);

        var memberships = await query.ToListWithPagination(req, metadata);

        return memberships.Select(m => m.ToGetMembershipsResponse());
    }

    public async Task UpdateMembership(Guid id, UpdateMembershipRequest req) {
        var membership = await _membershipRepository.GetMembershipById(id);

        await _membershipRepository.UpdateMembership(membership, req);
    }
}