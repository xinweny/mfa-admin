using Mfa.Addresses;

namespace Mfa.Memberships;

public class CreateMembershipRequest {
    public required MembershipTypes MembershipType { get; set; }
    public required IEnumerable<MemberDto> Members { get; set; }
    public CreateAddressDto? Address { get; set; }

    public class MemberDto {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class CreateAddressDto {
        public required string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required Provinces Province { get; set; }
    }
}