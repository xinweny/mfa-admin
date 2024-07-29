namespace Mfa.Features.MembershipPayments;

public class MembershipPayment {
    public int Id { get; set; }
    public int Year { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public double Amount { get; set; }

    public required Memberships.Membership Membership;
}

public enum PaymentMethod {
    EFT,
    Cash,
    Cheque
}