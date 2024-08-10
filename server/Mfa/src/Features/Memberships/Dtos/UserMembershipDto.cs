using Mfa.Enums;

namespace Mfa.Dtos;

public class UserMembershipDto {
    public required int Id { get; set; }
    public required MembershipTypes MembershipType { get; set; }
    public int? AddressId { get; set; }
    public AddressDto? Address { get; set; }
    public IEnumerable<MembershipUsersDto>? Users { get; set; }
}