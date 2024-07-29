using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Features.Memberships;
using Mfa.Features.BoardMembers;

namespace Mfa.Features.Users;

public class User {
    [Key]
    public int Id { get; set; }

    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    public int? PhoneNumber { get; set; }

    [Required]
    public required string Email { get; set; }

    public string? Title { get; set; }

    public int? MembershipId { get; set; }

    [ForeignKey(nameof(MembershipId))]
    public Membership? Membership;

    [InverseProperty("User")]
    public ICollection<BoardMember>? BoardPositions;

    [InverseProperty("User")]
    public ICollection<Hosts.Host>? Hosts;

    [InverseProperty("User")]
    public ICollection<Delegates.Delegate>? Delegates;
}