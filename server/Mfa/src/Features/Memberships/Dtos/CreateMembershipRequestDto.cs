using Mfa.Enums;

namespace Mfa.Dtos;

public class CreateMembershipRequestDto {
    public required MembershipTypes MembershipType { get; set; }

    public int? AddressId { get; set; }
}