namespace Mfa.Modules.Due;

public interface IDueRepository {
    Task<DueModel> GetDueById(int id);
    Task<IEnumerable<DueModel>> GetDues(GetDuesRequest req);
    Task<IEnumerable<DueModel>> GetMembershipDues(int membershipId);
    Task CreateDues(int membershipId, IEnumerable<DueModel> dues);
    Task UpdateDue(DueModel due, UpdateDueRequest req);
    Task DeleteDue(DueModel due);
}