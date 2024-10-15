using MfaApi.Modules.Membership;

namespace MfaApi.Modules.Member;

public class GetMembersByDateResponse {
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly JoinedDate { get; set; }
    public Guid MembershipId { get; set; }
    public MembershipDto? Membership { get; set; }

    public class MembershipDto {
        public required Guid Id { get; set; }
        public required MembershipType MembershipType { get; set; }
    }
}