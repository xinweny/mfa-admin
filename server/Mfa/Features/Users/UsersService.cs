using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Mfa.Database;

namespace Mfa.Features.Users;

public class UsersService {
    private readonly MfaDbContext _context;

    public UsersService(MfaDbContext context) {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync() {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id) {
        return await _context.Users.FindAsync(id);
    } 
}