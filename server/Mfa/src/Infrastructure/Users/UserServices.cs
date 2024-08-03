using Microsoft.EntityFrameworkCore;

using Mfa.Database;

namespace Mfa.Infrastructure.Users;

public class UserServices {
    private readonly MfaDbContext _db;
    private readonly ILogger<UserServices> _logger;

    public UserServices(MfaDbContext db, ILogger<UserServices> logger) {
        _db = db;
        _logger = logger;
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

    public async Task CreateUserAsync(CreateUserDto data) {
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

    public async Task UpdateUserAsync(int id, UpdateUserDto data) {
        try {
            User user = await GetUserByIdAsync(id)
                ?? throw new Exception("User with id {id} not found.");

            _db.Entry(user).CurrentValues.SetValues(data);
            
            await _db.SaveChangesAsync();
        }
        catch (Exception _e) {
            throw;
        }
    }

    private static void SearchUsersByFullName(string query, IQueryable<User> users) {
        string formattedQuery = query.ToUpper();

        users = users.Where(user => $"{user.FirstName} {user.LastName}".Contains(formattedQuery, StringComparison.CurrentCultureIgnoreCase));
    }
}