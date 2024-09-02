using MfaApi.Core.Constants;

namespace MfaApi.Modules.Due;

public class GetDuesRequest {
    public DateOnly? DateFrom { get; set; }
    public DateOnly? DateTo { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; } = [];
    public SortOrder SortPaymentDate { get; set; }
}