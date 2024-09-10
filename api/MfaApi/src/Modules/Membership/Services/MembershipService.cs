using MfaApi.Core.Constants;
using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Membership;

public class MembershipService: IMembershipService {
    private readonly IMembershipRepository _membershipRepository;

    public MembershipService(IMembershipRepository membershipRepository) {
        _membershipRepository = membershipRepository;
    }

    public async Task<CreateMembershipResponse> CreateMembership(CreateMembershipRequest req) {
        var membership = req.ToMembership();

        await _membershipRepository.CreateMembership(membership);

        return membership.ToCreateMembershipResponse();
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

    public async Task<GetMembershipsSummaryResponse> GetMembershipsSummary(GetMembershipsSummaryRequest req) {
        var memberships = await _membershipRepository.GetMembershipWithDues(req.DueYear);

        if (memberships.Count() == 0) {
            return new GetMembershipsSummaryResponse {
                TotalYearlyDuesOwed = 0,
                TotalYearlyDuesPaid = 0,
            };
        }

        return new GetMembershipsSummaryResponse {
            TotalYearlyDuesOwed = memberships
                .Select(m => {
                    return m.MembershipType switch {
                        MembershipType.Single => MfaConstants.SingleMembershipCost,
                        MembershipType.Family => MfaConstants.FamilyMembershipCost,
                        _ => 0,
                    };
                })
                .Aggregate((a, b) => a + b),
            TotalYearlyDuesPaid = memberships
                .Where(m => m.Dues.Count > 0)
                .Select(m => m.Dues.First().AmountPaid)
                .Aggregate((a, b) => a + b),
        };
    }
}