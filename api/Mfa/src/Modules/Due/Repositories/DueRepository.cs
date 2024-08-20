using Microsoft.EntityFrameworkCore;

using Mfa.Database;

namespace Mfa.Modules.Due;

public class DueRepository : IDueRepository
{
    private readonly MfaDbContext _context;

    public DueRepository(MfaDbContext context) {
        _context = context;
    }

    public async Task CreateDues(IEnumerable<DueModel> dues)
    {
        _context.Dues.AddRange(dues);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteDue(DueModel due)
    {
        _context.Dues.Remove(due);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<DueModel>> GetDues(GetDuesRequest? req)
    {
        var duesQuery = _context.Dues;

        if (req?.MembershipId != null) duesQuery.Where(d => d.Id == req.MembershipId);

        return await duesQuery.ToListAsync();;
    }

    public async Task UpdateDue(DueModel due, UpdateDueRequest req)
    {
        _context.Dues.Entry(due).CurrentValues.SetValues(req);

        await _context.SaveChangesAsync();
    }
}