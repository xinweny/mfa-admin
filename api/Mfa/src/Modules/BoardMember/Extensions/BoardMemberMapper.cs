namespace Mfa.Modules.BoardMember;

public static class BoardMemberMapper {
    public static BoardMemberModel ToBoardMember(this CreateBoardMemberRequest req) {
        return new BoardMemberModel {
            BoardPosition = req.BoardPosition,
            StartDate = req.StartDate,
            EndDate = req.EndDate,
            MemberId = req.MemberId,
        };
    }

    public static GetMemberBoardMembersResponse ToGetMemberBoardMembersResponse(this BoardMemberModel boardMember) {
        return new GetMemberBoardMembersResponse {
            Id = boardMember.Id,
            BoardPosition = boardMember.BoardPosition,
            StartDate = boardMember.StartDate,
            EndDate = boardMember.EndDate,
            MemberId = boardMember.MemberId,
        };
    }

    public static GetBoardMembersResponse ToGetBoardMembersResponse(this BoardMemberModel boardMember) {
        var member = boardMember.Member;

        return new GetBoardMembersResponse {
            Id = boardMember.Id,
            BoardPosition = boardMember.BoardPosition,
            StartDate = boardMember.StartDate,
            EndDate = boardMember.EndDate,
            MemberId = boardMember.MemberId,
            Member = member != null
                ? new GetBoardMembersResponse.MemberDto {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                }
                : null,
        };
    }
}