namespace MfaApi.Modules.Due;

public interface IDueRepository {
    Task<DueModel> GetDueById(Guid id);
    IQueryable<DueModel> GetDuesQuery(GetDuesRequest req);
    Task<IEnumerable<DueModel>> GetMembershipDues(Guid membershipId);
    Task CreateDues(IEnumerable<DueModel> dues);
    Task UpdateDue(DueModel due, UpdateDueRequest req);
    Task DeleteDue(DueModel due);
}