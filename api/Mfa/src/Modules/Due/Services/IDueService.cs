namespace Mfa.Modules.Due;

public interface IDueService {
    Task<IEnumerable<GetMembershipDuesResponse>> GetMembershipDues(int membershipId, GetDuesRequest? req);
    Task<IEnumerable<GetDuesResponse>> GetDues(GetDuesRequest? req);
    Task CreateDues(IEnumerable<CreateDueRequest> req);
    Task UpdateDue(int id, UpdateDueRequest req);
    Task DeleteDue(int id);
}