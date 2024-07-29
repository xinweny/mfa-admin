namespace Mfa.Features.Hosts;

public class Host {
    public int Id { get; set; }
    public int Year { get; set; }

    public required Users.User User;
}