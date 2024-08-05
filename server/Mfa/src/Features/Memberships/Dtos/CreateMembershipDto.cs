using Mfa.Enums;

namespace Mfa.Dtos;

public record CreateMembershipDto {
    public required MembershipTypes MembershipType { get; init; }

    public int? AddressId { get; init; }
}