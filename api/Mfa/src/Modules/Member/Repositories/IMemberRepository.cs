namespace Mfa.Modules.Member;

public interface IMemberRepository {
    Task<IEnumerable<MemberModel>> GetMembers(GetMembersRequest req);
    Task<MemberModel?> GetMemberById(int id);
    Task<MemberModel?> GetMemberById(int id, bool includeMembership);
    Task CreateMember(MemberModel member);
    Task CreateMembers(IEnumerable<MemberModel> members);
    Task UpdateMember(MemberModel member, UpdateMemberRequest req);
    Task DeleteMember(MemberModel member);
}