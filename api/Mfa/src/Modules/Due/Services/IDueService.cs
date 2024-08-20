namespace Mfa.Modules.Due;

public interface IDueService {
    Task CreateDues(IEnumerable<CreateDueRequest> req);
    Task UpdateDue(int dueId, UpdateDueRequest req);
    Task DeleteDue(int dueId);
}