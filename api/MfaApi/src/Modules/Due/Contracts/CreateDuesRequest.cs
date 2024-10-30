namespace MfaApi.Modules.Due;

public class CreateDuesRequest {
    public required List<CreateDueRequest> Dues { get; set; }
    
    public class CreateDueRequest {
        public required Guid MembershipId { get; set; }
        public required int Year { get; set; }
        public required int AmountPaid { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
        public required DateTime PaymentDate { get; set; }
    }
}