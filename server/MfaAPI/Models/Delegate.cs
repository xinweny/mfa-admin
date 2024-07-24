namespace MfaAPI.Models {
    public class Delegate {
        public int Id { get; set; }
        public int Year { get; set; }

        public required User User;
    }
}