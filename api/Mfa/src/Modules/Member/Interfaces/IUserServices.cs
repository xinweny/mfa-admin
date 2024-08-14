using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMemberServices {
    Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest dto);
    Task<GetMemberResponse> GetMemberById(int id);
    Task CreateMember(CreateMemberRequest dto);
    Task UpdateMember(int id, UpdateMemberRequest dto);
    Task DeleteMember(int id);
}