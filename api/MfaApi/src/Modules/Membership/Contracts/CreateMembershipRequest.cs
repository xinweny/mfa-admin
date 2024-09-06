using MfaApi.Modules.Address;

namespace MfaApi.Modules.Membership;

public class CreateMembershipRequest {
    public required MembershipType MembershipType { get; set; }
    public required List<MemberDto> Members { get; set; } = [];
    public required DateTime StartDate { get; set; }
    public CreateAddressDto? Address { get; set; }

    public class MemberDto {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime JoinedDate { get; set; }
    }

    public class CreateAddressDto {
        public required string Line1 { get; set; }
        public string? Line2 { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required Province Province { get; set; }
    }
}