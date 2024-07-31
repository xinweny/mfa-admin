using Microsoft.EntityFrameworkCore;

using Mfa.Database;
using Microsoft.AspNetCore.Mvc;

namespace Mfa.Infrastructure.Users;

public class UsersService {
    private readonly MfaDbContext _db;

    public UsersService(MfaDbContext db) {
        _db = db;
    }

        public async Task<User?> GetUserByIdAsync(int id) {
        return await _db.Users.FindAsync(id);
    }

    public async Task<List<User>> GetQueriedUsersAsync(string? query) {
        var users = GetAllUsers();
        
        if (!string.IsNullOrEmpty(query)) SearchUsersByFullName(query, users);

        return await users.ToListAsync();
    }

    private IQueryable<User> GetAllUsers() {
        return from user in _db.Users
            select user;
    }

    private async Task CreateUserAsync(CreateUserDto data) {
        var user = new User() {
            FirstName = data.FirstName,
            LastName = data.LastName,
            Email = data.Email,
            PhoneNumber = data.PhoneNumber,
            Title = data.Title,
            MembershipId = data.MembershipId,
        };

        _db.Add(user);

        await _db.SaveChangesAsync();
    }

    private static void SearchUsersByFullName(string query, IQueryable<User> users) {
        string formattedQuery = query.ToUpper();

        users = users.Where(user => $"{user.FirstName} {user.LastName}".Contains(formattedQuery, StringComparison.CurrentCultureIgnoreCase));
    }
}