namespace Mfa.Features.Delegates;

public class Delegate {
    public int Id { get; set; }
    public int Year { get; set; }

    public required Users.User User;
}