namespace Mfa.Dtos;

using Mfa.Models;
using Mfa.Enums;

public record GetMembershipsResponse {
    public class Member {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }

    public required int Id { get; set; }
    public MembershipTypes MembershipType { get; set; }
    public IEnumerable<Member>? Members { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}