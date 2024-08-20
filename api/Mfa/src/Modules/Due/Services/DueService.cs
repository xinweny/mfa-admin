namespace Mfa.Modules.Due;

public class DueService : IDueService
{
    private readonly IDueRepository _dueRepository;

    public DueService(IDueRepository dueRepository) {
        _dueRepository = dueRepository;
    }

    public Task CreateDue(CreateDueRequest req)
    {
        throw new NotImplementedException();
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