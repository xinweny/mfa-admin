using Microsoft.EntityFrameworkCore;
using FluentValidation;

using MfaApi.Database;
using MfaApi.Core.Sort;
using MfaApi.Core.Utils;

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

    public IQueryable<DueModel> GetDuesQuery(GetDuesRequest req) {
        var query = _context.Dues.AsQueryable();

        query = query
            .Include(d => d.Membership)
            .ThenInclude(m => m != null ? m.Members : null);

        if (req.Year != null) {
            query = query.Where(d => d.Year == req.Year);
        }

        if (!string.IsNullOrEmpty(req.PaymentMethods)) {
            PaymentMethod[] paymentMethods = req.PaymentMethods.ParseAsEnumArray<PaymentMethod>();

            query = query.Where(d => paymentMethods.Contains(d.PaymentMethod));
        };

        if (req.MembershipType != null) {
            query = query.Where(d =>
                d.Membership != null && d.Membership.MembershipType == req.MembershipType
            );
        }

        if (req.DateFrom != null) {
            query = query.Where(d => d.PaymentDate >= DateOnly.FromDateTime((DateTime) req.DateFrom));
        }

        if (req.DateTo != null) {
            query = query.Where(d => d.PaymentDate <= DateOnly.FromDateTime((DateTime) req.DateTo));
        }

        query = query.Sort(d => d.PaymentDate, req.SortPaymentDate);
        query = query.Sort(d => d.Year, req.SortYear);

        return query;
    }

    public async Task<IEnumerable<DueModel>> GetMembershipDues(Guid membershipId) {
        var dues = await _context.Dues
            .AsNoTracking()
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