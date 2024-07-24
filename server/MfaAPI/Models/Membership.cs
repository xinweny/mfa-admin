namespace MfaAPI.Models {
    public class Membership {
        public int Id { get; set; }
        public required MembershipTypes Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<User> Users { get; } = [];
        public ICollection<MembershipPayments> Payments { get; } = [];
    }
    public enum MembershipTypes {
        Single,
        Family,
        Honorary
    }
}