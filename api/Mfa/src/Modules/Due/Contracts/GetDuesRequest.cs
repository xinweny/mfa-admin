using Mfa.Common.Enums;

namespace Mfa.Modules.Due;

public class GetDuesRequest {
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public IEnumerable<PaymentMethod> PaymentMethods { get; set; } = [];
    public SortOrder SortPaymentDate { get; set; } = SortOrder.None;
}