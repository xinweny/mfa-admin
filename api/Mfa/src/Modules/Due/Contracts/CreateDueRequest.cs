namespace Mfa.Modules.Due;

public class CreateDueRequest {
    public required int MembershipId { get; set; }
    public required int AmountPaid { get; set; }
    public required PaymentMethods PaymentMethod { get; set; }
    public required DateTime PaymentDate { get; set; }
}