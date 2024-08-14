using Mfa.Enums;

namespace Mfa.Dtos;

public class MemberMembership {
    public required int Id { get; set; }
    public required MembershipTypes MembershipType { get; set; }
    public int? AddressId { get; set; }
    public AddressDto? Address { get; set; }
    public IEnumerable<MembershipMember>? Members { get; set; }
}