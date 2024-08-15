using Mfa.Enums;

namespace Mfa.Dtos;

public class CreateMembershipRequest {
    public required MembershipTypes MembershipType { get; set; }
    public IEnumerable<MemberDto>? Members { get; set; }
    public AddressDto? Address { get; set; }

    public class MemberDto {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Title { get; set; }
    }

    public class AddressDto {
        public required string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required Provinces Province { get; set; }
    }
}