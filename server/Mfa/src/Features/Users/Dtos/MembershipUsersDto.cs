using Mfa.Enums;

namespace Mfa.Dtos;

public class MembershipUsersDto {
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}