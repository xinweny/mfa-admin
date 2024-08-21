using Mfa.Modules.Membership;

namespace Mfa.Modules.Member;

public interface IMemberRepository {
    Task<IEnumerable<MemberModel>> GetMembers(GetMembersRequest req);
    Task<MemberModel?> GetMemberById(int id);
    Task<MemberModel?> GetMemberById(int id, bool includeMembership);
    Task CreateMember(MemberModel member, MembershipModel membership);
    Task UpdateMember(MemberModel member, UpdateMemberRequest req);
    Task DeleteMember(MemberModel member, MembershipModel membership);
}