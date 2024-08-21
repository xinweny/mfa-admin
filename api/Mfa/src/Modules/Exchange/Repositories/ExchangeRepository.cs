using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Mfa.Database;
using Mfa.Common.Constants;
using Mfa.Modules.Member;

namespace Mfa.Modules.Exchange;

public class ExchangeRepository : IExchangeRepository
{
    private readonly MfaDbContext _context;
    private readonly IValidator<ExchangeModel> _validator;

    public ExchangeRepository(MfaDbContext context, IValidator<ExchangeModel> validator) {
        _context = context;
        _validator = validator;
    }

    public async Task CreateExchanges(int memberId, IEnumerable<ExchangeModel> exchanges) {
        var member = await _context.Members.FindAsync(memberId);

        if (member == null) throw new KeyNotFoundException("Associated member not found.");

        foreach (ExchangeModel exchange in exchanges) {
            _validator.ValidateAndThrow(exchange);
            member.Exchanges.Add(exchange);
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteExchange(ExchangeModel exchange) {
        _context.Exchanges.Remove(exchange);

        await _context.SaveChangesAsync();
    }

    public async Task<ExchangeModel> GetExchangeById(int id) {
        var exchange = await _context.Exchanges
            .FindAsync(id)
            ?? throw new KeyNotFoundException("Exchange not found.");

        return exchange;
    }

    public async Task<IEnumerable<ExchangeModel>> GetExchanges(GetExchangesRequest req) {
        var query = _context.Exchanges.AsQueryable();

        query.Include(e => e.Member);

        if (!string.IsNullOrEmpty(req.Query)) {
            query.Where(e =>
                e.Member != null
                    ? e.Member.DoesFullNameContainQuery(req.Query)
                    : false
            );
        }

        if (req.ExchangeType != null) query.Where(e => e.ExchangeType == req.ExchangeType);
        if (req.FromYear != null) query.Where(e => e.Year >= req.FromYear);
        if (req.ToYear != null) query.Where(e => e.Year <= req.ToYear);

        if (req.SortYear == SortOrder.Ascending) {
            query.OrderBy(e => e.Year);
        } else if (req.SortYear == SortOrder.Descending) {
            query.OrderByDescending(e => e.Year);
        }

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<ExchangeModel>> GetExchangesByMemberId(int memberId) {
        var exchanges = await _context.Exchanges
            .Where(e => e.MemberId == memberId)
            .OrderByDescending(e => e.Year)
            .ToListAsync();

        return exchanges;
    }

    public async Task UpdateExchange(ExchangeModel exchange, UpdateExchangeRequest req) {
        _context.Entry(exchange).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(exchange);

        await _context.SaveChangesAsync();
    }
}