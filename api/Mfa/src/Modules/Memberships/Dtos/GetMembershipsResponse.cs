using Mfa.Addresses;

namespace Mfa.Memberships;

public record GetMembershipsResponse {
    public required int Id { get; set; }
    public MembershipTypes MembershipType { get; set; }
    public IEnumerable<MemberDto>? Members { get; set; }
    public int? AddressId { get; set; }
    public AddressDto? Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public class MemberDto {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}