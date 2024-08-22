using MfaApi.Common.Constants;

namespace MfaApi.Modules.Due;

public class GetDuesRequest {
    public DateOnly? FromDate { get; set; }
    public DateOnly? ToDate { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; } = [];
    public SortOrder SortPaymentDate { get; set; } = SortOrder.None;
}