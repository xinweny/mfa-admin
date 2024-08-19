namespace Mfa.Members;

public interface IMemberService {
    Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest req);
    Task<GetMemberResponse> GetMemberById(int id);
    Task CreateMember(CreateMemberRequest req);
    Task UpdateMember(int id, UpdateMemberRequest req);
    Task DeleteMember(int id);
}