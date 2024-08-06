using Mfa.Enums;
using Mfa.Models;

namespace Mfa.Dtos;

public class IncludeMembershipDto {
    public required int Id { get; set; }
    public required MembershipTypes MembershipType { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
}