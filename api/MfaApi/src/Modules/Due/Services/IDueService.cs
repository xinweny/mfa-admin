namespace MfaApi.Modules.Due;

public interface IDueService {
    Task<IEnumerable<GetMembershipDuesResponse>> GetMembershipDues(Guid membershipId);
    Task<IEnumerable<GetDuesResponse>> GetDues(GetDuesRequest req);
    Task CreateDues(CreateDuesRequest req);
    Task UpdateDue(Guid id, UpdateDueRequest req);
    Task DeleteDue(Guid id);
}