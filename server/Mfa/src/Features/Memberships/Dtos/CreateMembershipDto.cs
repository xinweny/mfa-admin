using Mfa.Enums;

namespace Mfa.Dtos;

public class CreateMembershipDto {
    public required MembershipTypes Type { get; set; }

    public int? AddressId { get; set; }
}