using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mfa.Models;

public class Member {
    [Key]
    public int Id { get; set; }

    [Required]
    public required string FirstName { get; set; }
    [Required]
    public required string LastName { get; set; }
    [Required]
    public required string Email { get; set; }
    public int? PhoneNumber { get; set; }
    public string? Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [Required, ForeignKey(nameof(Membership))]
    public required int MembershipId { get; set; }
    public Membership? Membership;

    public ICollection<BoardPosition>? BoardPositions;
    public ICollection<Host>? Hosts;
    public ICollection<Delegate>? Delegates;

    public Member() {
        CreatedAt = DateTime.Now;
    }
}