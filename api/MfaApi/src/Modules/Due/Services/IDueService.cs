namespace MfaApi.Modules.Due;

public interface IDueService {
    Task<IEnumerable<GetMembershipDuesResponse>> GetMembershipDues(int membershipId);
    Task<IEnumerable<GetDuesResponse>> GetDues(GetDuesRequest req);
    Task CreateDues(CreateDuesRequest req);
    Task UpdateDue(int id, UpdateDueRequest req);
    Task DeleteDue(int id);
}