namespace Mfa.Dtos;

using Mfa.Enums;

public class UpdateMembershipRequest {
    public MembershipTypes? MembershipType { get; init; }
    public int? AddressId { get; set; }
}