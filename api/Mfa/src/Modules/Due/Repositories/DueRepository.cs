using Mfa.Data;
using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Models;

namespace Mfa.Repositories;

public class DueRepository : IDueRepository
{
    private readonly MfaDbContext _context;

    public DueRepository(MfaDbContext context) {
        _context = context;
    }

    public Task CreateDues(IEnumerable<Due> due)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDue(Due due)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Due>> GetDues(GetDuesRequest? req)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDue(Due due, UpdateDueRequest req)
    {
        throw new NotImplementedException();
    }
}