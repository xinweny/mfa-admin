using MfaApi.Core.Sort;
using MfaApi.Core.Pagination;
using MfaApi.Modules.Membership;

namespace MfaApi.Modules.Due;

public class GetDuesRequest: PaginationRequest {
    public int? Year { get; set; }
    public MembershipType? MembershipType { get; set; }
    public string? PaymentMethods { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public SortOrder? SortPaymentDate { get; set; }
    public SortOrder? SortYear { get; set; }
}