using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Membership;

public interface IMembershipService {
    Task<IEnumerable<GetMembershipsResponse>> GetMemberships(GetMembershipsRequest req, PaginationMetadata metadata);
    Task<GetMembershipResponse> GetMembershipById(Guid id);
    Task<CreateMembershipResponse> CreateMembership(CreateMembershipRequest req);
    Task UpdateMembership(Guid id, UpdateMembershipRequest req);
    Task DeleteMembership(Guid id);
    Task<GetMembershipsSummaryResponse> GetMembershipsSummary(GetMembershipsSummaryRequest req);
}