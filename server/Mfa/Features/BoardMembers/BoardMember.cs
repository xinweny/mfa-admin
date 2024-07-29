namespace Mfa.Features.BoardMembers;

public class BoardMember {
    public int Id { get; set; }
    public int Year { get; set; }
    public BoardPositions Position { get; set; }

    public required Users.User User;
}

public enum BoardPositions {
    President,
    VicePresident,
    Secretary,
    Treasurer,
    BoardMember
}