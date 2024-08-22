namespace MfaApi.Modules.Due;

public class GetMembershipDuesResponse {
    public required Guid Id { get; set; }
    public required Guid MembershipId { get; set; }
    public required int Year { get; set; }
    public required int AmountPaid { get; set; }
    public required PaymentMethod PaymentMethod { get; set; }
    public required DateOnly PaymentDate { get; set; }
}