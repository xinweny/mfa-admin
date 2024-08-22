using MfaApi.Modules.Membership;

namespace MfaApi.Modules.Due;

public class GetDuesResponse {
    public required int Id { get; set; }
    public required int MembershipId { get; set; }
    public required int Year { get; set; }
    public required int AmountPaid { get; set; }
    public required PaymentMethod PaymentMethod { get; set; }
    public required DateOnly PaymentDate { get; set; }
    public MembershipDto? Membership { get; set; }

    public class MembershipDto {
        public required int Id { get; set; }
        public required MembershipType MembershipType { get; set; }
        public required List<MemberDto> Members { get; set; }

        public class MemberDto {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
    }
}