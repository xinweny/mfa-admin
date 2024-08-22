namespace MfaApi.Modules.Due;

public class DueService : IDueService
{
    private readonly IDueRepository _dueRepository;

    public DueService(IDueRepository dueRepository) {
        _dueRepository = dueRepository;
    }

    public async Task CreateDues(CreateDuesRequest req) {
        await _dueRepository.CreateDues(req.MembershipId, req.ToDues());
    }

    public async Task DeleteDue(int id) {
        var due = await _dueRepository.GetDueById(id);

        await _dueRepository.DeleteDue(due);
    }

    public async Task<IEnumerable<GetMembershipDuesResponse>> GetMembershipDues(int membershipId) {
        var dues = await _dueRepository.GetMembershipDues(membershipId);

        return dues.Select(d => d.ToGetMembershipDuesResponse());
    }

    public async Task<IEnumerable<GetDuesResponse>> GetDues(GetDuesRequest req) {
        var dues = await _dueRepository.GetDues(req);

        return dues.Select(d => d.ToGetDuesResponse());
    }

    public async Task UpdateDue(int id, UpdateDueRequest req) {
        var due = await _dueRepository.GetDueById(id);

        await _dueRepository.UpdateDue(due, req);
    }
}