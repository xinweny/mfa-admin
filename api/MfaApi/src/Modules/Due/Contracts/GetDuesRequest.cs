using MfaApi.Core.Constants;
using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Due;

public class GetDuesRequest: PaginationRequest {
    public int? Year { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; } = [];
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public SortOrder? SortPaymentDate { get; set; }
    public SortOrder? SortYear { get; set; }
}