namespace Mfa.Models {
    public class MembershipPayments {
        public int Id { get; set; }
        public int Year { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public double Amount { get; set; }

        public required Membership Membership;
    }

    public enum PaymentMethod {
        EFT,
        Cash,
        Cheque
    }
}