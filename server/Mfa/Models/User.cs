namespace Mfa.Models {
    public class User {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public string? Title { get; set; }

        public Membership? Membership;
        public ICollection<BoardMember>? BoardPositions;
        public ICollection<Host>? Hosts;
        public ICollection<Delegate>? Delegates;
    }
}