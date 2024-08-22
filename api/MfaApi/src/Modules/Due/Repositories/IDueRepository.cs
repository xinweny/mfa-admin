namespace MfaApi.Modules.Due;

public interface IDueRepository {
    Task<DueModel> GetDueById(Guid id);
    Task<IEnumerable<DueModel>> GetDues(GetDuesRequest req);
    Task<IEnumerable<DueModel>> GetMembershipDues(Guid membershipId);
    Task CreateDues(Guid membershipId, IEnumerable<DueModel> dues);
    Task UpdateDue(DueModel due, UpdateDueRequest req);
    Task DeleteDue(DueModel due);
}