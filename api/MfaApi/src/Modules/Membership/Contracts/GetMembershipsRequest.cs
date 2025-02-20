using MfaApi.Core.Sort;
using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Membership;

public class GetMembershipsRequest: PaginationRequest {
    public int YearPaid { get; set; } = DateTime.UtcNow.Year;
    public string? Query { get; set; }
    public MembershipType? MembershipType { get; set; }
    public SortOrder? SortStartDate { get; set; }
    public bool? HasPaid { get; set; }
    public DateTime? SinceFrom { get; set; }
    public DateTime? SinceTo { get; set; }
    public bool? IsActive { get; set; }
}