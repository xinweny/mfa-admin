using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using MfaApi.Common.Constants;
using MfaApi.Database;

namespace MfaApi.Modules.BoardMember;

public class BoardMemberRepository: IBoardMemberRepository {
    private readonly MfaDbContext _context;
    private readonly IValidator<BoardMemberModel> _validator;

    public BoardMemberRepository(MfaDbContext context, IValidator<BoardMemberModel> validator) {
        _context = context;
        _validator = validator;
    }

    public async Task CreateBoardMember(BoardMemberModel boardMember) {
        var member = await _context.Members.FindAsync(boardMember.MemberId);

        if (member == null) throw new KeyNotFoundException("Associated member not found.");

        _validator.ValidateAndThrow(boardMember);

        _context.Add(boardMember);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteBoardMember(BoardMemberModel boardMember) {
        _context.BoardMembers.Remove(boardMember);

        await _context.SaveChangesAsync();
    }

    public async Task<BoardMemberModel> GetBoardMemberById(Guid id) {
        var boardMember = await _context.BoardMembers
            .Include(b => b.Member)
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Board member not found.");

        return boardMember;
    }

    public async Task<IEnumerable<BoardMemberModel>> GetBoardMembers(GetBoardMembersRequest req) {
        var query = _context.BoardMembers.AsQueryable();

        query = query.Include(b => b.Member);

        if (!req.BoardPositions.IsNullOrEmpty()) query.Where(b => req.BoardPositions!.Contains(b.BoardPosition));
        if (req.DateFrom != null) {
            query = query.Where(
                b => b.StartDate >= req.DateFrom
                && (b.EndDate == null || b.EndDate <= req.DateFrom)
            );
        }
        if (req.DateTo != null) {
            query = query.Where(
                b => b.StartDate <= req.DateTo
                && (b.EndDate == null || b.EndDate <= req.DateTo)
            );
        }

        if (SortOrder.Ascending.Equals(req.SortDate)) {
            query = query.OrderBy(b => b.StartDate);
        } else if (SortOrder.Descending.Equals(req.SortDate)) {
            query = query.OrderByDescending(b => b.StartDate);
        }

        if (SortOrder.Ascending.Equals(req.SortTimeServed)) {
            query = query.OrderBy(b => (b.EndDate ?? DateOnly.FromDateTime(DateTime.Now)).DayNumber - b.StartDate.DayNumber);
        } else if (SortOrder.Descending.Equals(req.SortTimeServed)) {
            query = query.OrderByDescending(b => (b.EndDate ?? DateOnly.FromDateTime(DateTime.Now)).DayNumber - b.StartDate.DayNumber);
        }

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<BoardMemberModel>> GetMemberBoardMembers(Guid memberId) {
        var boardMembers = await _context.BoardMembers
            .Where(b => b.MemberId == memberId)
            .OrderByDescending(b => b.StartDate)
            .ToListAsync();

        return boardMembers;
    }

    public async Task UpdateBoardMember(BoardMemberModel boardMember, UpdateBoardMemberRequest req) {
        _context.Entry(boardMember).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(boardMember);

        await _context.SaveChangesAsync();
    }
}