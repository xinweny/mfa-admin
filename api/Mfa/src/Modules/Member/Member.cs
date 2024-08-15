using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mfa.Models;

[Table("members")]
public class Member {
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("first_name"), Required]
    public required string FirstName { get; set; }
    [Column("last_name"), Required]
    public required string LastName { get; set; }
    [Column("email"), Required]
    public required string Email { get; set; }
    [Column("phone_number")]
    public int? PhoneNumber { get; set; }
    [Column("title")]
    public string? Title { get; set; }
    [Column("created_at"), Required]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("membership_id"), Required, ForeignKey(nameof(Membership))]
    public required int MembershipId { get; set; }
    public Membership? Membership;
    [Column("user_id"), ForeignKey(nameof(User))]
    public int? UserId { get; set; }
    public User? User;

    public ICollection<BoardMember>? BoardPositions;
    public ICollection<Host>? Hosts;
    public ICollection<Delegate>? Delegates;

    public Member() {
        CreatedAt = DateTime.Now;
    }
}