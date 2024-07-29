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

    [ForeignKey(nameof(Membership))]
    public int? MembershipId { get; set; }

    public Membership? Membership;

    public ICollection<BoardMember>? BoardPositions;

    public ICollection<Hosts.Host>? Hosts;

    public ICollection<Delegates.Delegate>? Delegates;
}