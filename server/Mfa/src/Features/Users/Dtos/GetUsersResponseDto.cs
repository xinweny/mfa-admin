using Mfa.Enums;
using Mfa.Models;

namespace Mfa.Dtos;

public class GetUsersResponseDto {
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public int? PhoneNumber { get; set; }
    public string? Title { get; set; }
    public required int MembershipId { get; set; }
    public required MembershipDto Membership { get; set; }

    public class MembershipDto {
        public required int Id { get; set; }
        public required MembershipTypes MembershipType { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
    }
}