namespace Mfa.Modules.Due;

public interface IDueRepository {
    Task<IEnumerable<DueModel>> GetDues(GetDuesRequest? req);
    Task CreateDues(IEnumerable<DueModel> dues);
    Task UpdateDue(DueModel due, UpdateDueRequest req);
    Task DeleteDue(DueModel due);
}