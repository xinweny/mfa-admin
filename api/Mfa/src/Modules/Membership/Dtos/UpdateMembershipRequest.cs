namespace Mfa.Dtos;

using Mfa.Enums;

public class UpdateMembershipRequest {
    public MembershipTypes? MembershipType { get; set; }
    public int? AddressId { get; set; }
}