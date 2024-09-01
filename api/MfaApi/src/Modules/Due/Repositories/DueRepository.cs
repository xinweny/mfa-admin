using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using FluentValidation;

using MfaApi.Common.Constants;
using MfaApi.Database;

namespace MfaApi.Modules.Due;

public class DueRepository : IDueRepository
{
    private readonly MfaDbContext _context;
    private readonly IValidator<DueModel> _validator;

    public DueRepository(MfaDbContext context, IValidator<DueModel> validator) {
        _context = context;
        _validator = validator;
    }

    public async Task CreateDues(Guid membershipId, IEnumerable<DueModel> dues) {
        var membership = await _context.Memberships
            .Include(m => m.Dues)
            .Where(m => m.Id == membershipId)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Associated membership not found.");

        foreach (DueModel due in dues) {
            _validator.ValidateAndThrow(due);
            membership.Dues.Add(due);
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteDue(DueModel due) {
        _context.Dues.Remove(due);

        await _context.SaveChangesAsync();
    }

    public async Task<DueModel> GetDueById(Guid id) {
        var due = await _context.Dues
            .Include(d => d.Membership)
            .Where(d => d.Id == id)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Due not found.");

        return due;
    }

    public async Task<IEnumerable<DueModel>> GetDues(GetDuesRequest req) {
        var query = _context.Dues.AsQueryable();

        if (!req.PaymentMethods.IsNullOrEmpty()) {
            query = query.Where(d => req.PaymentMethods.Contains(d.PaymentMethod));
        };
        if (req.DateFrom != null) {
            query = query.Where(d => d.PaymentDate >= req.DateFrom);
        }
        if (req.DateTo != null) {
            query = query.Where(d => d.PaymentDate <= req.DateTo);
        }
        
        if (SortOrder.Ascending.Equals(req.SortPaymentDate)) {
            query = query.OrderBy(d => d.PaymentDate);
        } else if (SortOrder.Descending.Equals(req.SortPaymentDate)) {
            query = query.OrderByDescending(d => d.PaymentDate);
        }

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<DueModel>> GetMembershipDues(Guid membershipId) {
        var dues = await _context.Dues
            .Where(d => d.MembershipId == membershipId)
            .Include(d => d.Membership)
            .ThenInclude(m => m != null ? m.Members : null)
            .ToListAsync();

        return dues;
    }

    public async Task UpdateDue(DueModel due, UpdateDueRequest req) {
        _context.Dues.Entry(due).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(due);

        await _context.SaveChangesAsync();
    }
}