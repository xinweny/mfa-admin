namespace Mfa.Features.Users;

public class User {
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int? PhoneNumber { get; set; }
    public required string Email { get; set; }
    public string? Title { get; set; }

    public Memberships.Membership? Membership;
    public ICollection<BoardMembers.BoardMember>? BoardPositions;
    public ICollection<Hosts.Host>? Hosts;
    public ICollection<Delegates.Delegate>? Delegates;
}