namespace Mfa.Modules.Due;

public class DueService : IDueService
{
    private readonly IDueRepository _dueRepository;

    public DueService(IDueRepository dueRepository) {
        _dueRepository = dueRepository;
    }

    public async Task CreateDues(IEnumerable<CreateDueRequest> req)
    {
        var dues = req.Select(r => r.ToDue());

        await _dueRepository.CreateDues(dues);
    }

    public async Task DeleteDue(int id)
    {
        var due = await _dueRepository.GetDueById(id)
            ?? throw new KeyNotFoundException();

        await _dueRepository.DeleteDue(due);
    }

    public async Task<IEnumerable<GetDuesResponse>> GetDues(int? membershipId, GetDuesRequest? req)
    {
        var dues = await _dueRepository.GetDues(membershipId, req);

        return dues.Select(d => d.ToGetDuesResponse());
    }

    public async Task UpdateDue(int id, UpdateDueRequest req)
    {
        var due = await _dueRepository.GetDueById(id)
            ?? throw new KeyNotFoundException();

        await _dueRepository.UpdateDue(due, req);
    }
}