using Mfa.Enums;

namespace Mfa.Dtos;

public class GetDuesRequest {
    public int? MembershipId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public IEnumerable<PaymentMethods>? PaymentMethods { get; set; }
}