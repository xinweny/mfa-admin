namespace Mfa.Dtos;

using Mfa.Models;
using Mfa.Enums;

public record GetMembershipsResponse {
    public required int Id { get; set; }
    public MembershipTypes MembershipType { get; set; }
    public IEnumerable<MembershipMember>? Members { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}