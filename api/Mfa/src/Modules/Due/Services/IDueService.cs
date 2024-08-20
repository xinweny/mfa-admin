namespace Mfa.Modules.Due;

public interface IDueService {
    Task<IEnumerable<GetDuesResponse>> GetDues(int? membershipId, GetDuesRequest? req);
    Task CreateDues(IEnumerable<CreateDueRequest> req);
    Task UpdateDue(int id, UpdateDueRequest req);
    Task DeleteDue(int id);
}