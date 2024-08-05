namespace Mfa.Dtos;

using Mfa.Enums;

public record UpdateMembershipDto {
    public MembershipTypes? MembershipType { get; init; }

    public int? AddressId { get; init; }
}