using Mfa.Common.Enums;

namespace Mfa.Modules.Due;

public class GetDuesRequest {
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public IEnumerable<PaymentMethod> PaymentMethod { get; set; } = [];
    public SortOrder PaymentDate { get; set; } = SortOrder.None;
}