namespace MfaApi.Modules.Due;

public class CreateDuesRequest {
    public required int MembershipId { get; set; }
    public required List<CreateDueRequest> Dues { get; set; }
    
    public class CreateDueRequest {
        public required int Year { get; set; }
        public required int AmountPaid { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
        public required DateOnly PaymentDate { get; set; }
    }
}