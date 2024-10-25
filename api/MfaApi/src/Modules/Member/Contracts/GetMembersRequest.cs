using MfaApi.Core.Sort;
using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Member;

public class GetMembersRequest: PaginationRequest {
    public string? Query { get; set; }
    public DateTime? JoinedFrom { get; set; }
    public DateTime? JoinedTo { get; set; }
    public bool? IsMississaugaResident { get; set; }
    public SortOrder? SortFirstName { get; set; }
    public SortOrder? SortLastName { get; set; }
    public SortOrder? SortJoinedDate { get; set; }
    public bool ShowArchived { get; set; } = false;
}