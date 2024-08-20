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

    public Task DeleteDue(int dueId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDue(int dueId, UpdateDueRequest req)
    {
        throw new NotImplementedException();
    }
}