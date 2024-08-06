namespace Mfa.Dtos;

using Mfa.Models;
using Mfa.Enums;

public record GetMembershipResponseDto {
    public required int Id { get; set; }
    public MembershipTypes MembershipType { get; set; }
    public virtual ICollection<User>? Users { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}