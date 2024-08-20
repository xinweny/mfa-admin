namespace Mfa.Modules.Due;

public interface IDueRepository {
    Task<DueModel?> GetDueById(int id);
    Task<IEnumerable<DueModel>> GetDues(int? membershipId, GetDuesRequest? req);
    Task CreateDues(IEnumerable<DueModel> dues);
    Task UpdateDue(DueModel due, UpdateDueRequest req);
    Task DeleteDue(DueModel due);
}