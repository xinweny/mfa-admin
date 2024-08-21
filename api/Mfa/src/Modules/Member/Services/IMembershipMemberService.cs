namespace Mfa.Modules.Member;

public interface IMembershipMemberService {
    Task CreateMember(CreateMemberRequest req, int membershipId);
    Task DeleteMember(int id, int membershipId);
}