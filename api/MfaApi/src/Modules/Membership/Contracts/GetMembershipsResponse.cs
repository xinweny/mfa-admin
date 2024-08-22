using MfaApi.Modules.Address;

namespace MfaApi.Modules.Membership;

public record GetMembershipsResponse {
    public required Guid Id { get; set; }
    public MembershipType MembershipType { get; set; }
    public List<MemberDto>? Members { get; set; }
    public Guid? AddressId { get; set; }
    public AddressDto? Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public class MemberDto {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}