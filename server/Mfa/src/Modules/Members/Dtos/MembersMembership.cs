using Mfa.Enums;

namespace Mfa.Dtos;

public class MembersMembership {
    public required int Id { get; set; }
    public required MembershipTypes MembershipType { get; set; }
    public int? AddressId { get; set; }
    public AddressDto? Address { get; set; }
}