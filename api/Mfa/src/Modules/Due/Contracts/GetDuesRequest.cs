using Mfa.Common.Constants;

namespace Mfa.Modules.Due;

public class GetDuesRequest {
    public DateOnly? FromDate { get; set; }
    public DateOnly? ToDate { get; set; }
    public IEnumerable<PaymentMethod> PaymentMethods { get; set; } = [];
    public SortOrder SortPaymentDate { get; set; } = SortOrder.None;
}