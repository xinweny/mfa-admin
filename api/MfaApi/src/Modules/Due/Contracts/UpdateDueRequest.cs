namespace MfaApi.Modules.Due;

public class UpdateDueRequest {
    public int? AmountPaid { get; set; }
    public int? Year { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public DateOnly? PaymentDate { get; set; }
}