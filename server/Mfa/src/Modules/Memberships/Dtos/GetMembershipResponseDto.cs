namespace Mfa.Dtos;

using Mfa.Enums;

public record GetMembershipResponseDto {
    public required int Id { get; set; }
    public MembershipTypes MembershipType { get; set; }
    public IEnumerable<MembershipMembersDto>? Members { get; set; }
    public int? AddressId { get; set; }
    public AddressDto? Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}