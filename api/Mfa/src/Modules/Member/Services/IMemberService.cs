namespace Mfa.Modules.Member;

public interface IMemberService {
    Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest req);
    Task<GetMemberResponse> GetMemberById(int id);
    Task UpdateMember(int id, UpdateMemberRequest req);
}