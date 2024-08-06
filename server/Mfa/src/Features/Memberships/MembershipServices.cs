using Microsoft.EntityFrameworkCore;

using Mfa.Database;
using Mfa.Models;
using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Services;
public class MembershipServices: IMembershipServices {
    private readonly MfaDbContext _context;

    public MembershipServices(MfaDbContext context) {
        _context = context;
    }

    public Task CreateMembershipAsync(CreateMembershipRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMembershipAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Membership> GetMembershipByIdAsync(int id)
    {
        Membership membership = await _context.Memberships
            .Include(m =>
                m.Users
                    .Select(user => new { user.Id, user.FirstName, user.LastName })
            )
            .Include(m => m.Address)
            .FirstOrDefaultAsync(m => m.Id == id)    
            ?? throw new KeyNotFoundException();

        return membership;
    }

    public Task<IEnumerable<Membership>> GetMembershipsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateMembershipAsync(int id, UpdateMembershipRequestDto dto)
    {
        throw new NotImplementedException();
    }
}