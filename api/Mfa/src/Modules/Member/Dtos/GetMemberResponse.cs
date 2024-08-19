using Mfa.Enums;

namespace Mfa.Dtos;

public class GetMemberResponse {
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public required int MembershipId { get; set; }
    public required MembershipDto Membership { get; set; }

    public class MembershipDto {
        public class MemberDto {
            public required int Id { get; set; }
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
        }

        public required int Id { get; set; }
        public required MembershipTypes MembershipType { get; set; }
        public int? AddressId { get; set; }
        public AddressDto? Address { get; set; }
        public IEnumerable<MemberDto>? Members { get; set; }
    }
}