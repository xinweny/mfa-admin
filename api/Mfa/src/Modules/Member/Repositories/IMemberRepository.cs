namespace Mfa.Modules.Member;

public interface IMemberRepository {
    Task<IEnumerable<MemberModel>> GetMembers(GetMembersRequest req);
    Task<MemberModel> GetMemberById(int id);
    Task CreateMember(MemberModel member);
    Task UpdateMember(MemberModel member, UpdateMemberRequest req);
    Task DeleteMember(MemberModel member);
}