using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Member;

public interface IMemberService {
    Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest req, PaginationMetadata metadata);
    Task<GetMemberResponse> GetMemberById(Guid id);
    Task UpdateMember(Guid id, UpdateMemberRequest req);
    Task CreateMember(CreateMemberRequest req);
    Task DeleteMember(Guid id);
}