namespace Mfa.Dtos;

using Mfa.Enums;

public class UpdateMembershipRequestDto {
    public MembershipTypes? MembershipType { get; init; }
    public int? AddressId { get; set; }
}