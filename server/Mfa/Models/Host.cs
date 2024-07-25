namespace Mfa.Models {
    public class Host {
        public int Id { get; set; }
        public int Year { get; set; }

        public required User User;
    }
}