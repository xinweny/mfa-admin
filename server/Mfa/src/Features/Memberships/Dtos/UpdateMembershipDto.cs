namespace Mfa.Dtos;

using Mfa.Enums;

public class UpdateMembershipDto {
    public MembershipTypes? Type { get; set; }

    public int? AddressId { get; set; }
}