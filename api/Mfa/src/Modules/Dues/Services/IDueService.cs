namespace Mfa.Dues;

public interface IDueService {
    Task CreateDue(CreateDueRequest req);
    Task UpdateDue(int dueId, UpdateDueRequest req);
    Task DeleteDue(int dueId);
}