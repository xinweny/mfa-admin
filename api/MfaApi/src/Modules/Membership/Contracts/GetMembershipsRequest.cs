using MfaApi.Common.Constants;

namespace MfaApi.Modules.Membership;

public class GetMembershipsRequest {
    public int? YearPaid { get; set; }
    public string? Query { get; set; }
    public SortOrder? SortStartDate { get; set; }
}