namespace Mfa.Modules.Due;

public class UpdateDueRequest {
    public required int AmountPaid { get; set; }
    public required PaymentMethods PaymentMethod { get; set; }
    public required DateTime PaymentDate { get; set; }
}