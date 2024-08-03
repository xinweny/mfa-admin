using Microsoft.EntityFrameworkCore;

using Mfa.Database;
using Mfa.Models;
using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Services;

public class UserServices: IUserServices {
    private readonly MfaDbContext _context;

    public UserServices(MfaDbContext context) {
        _context = context;
    }

        public async Task<User> GetUserByIdAsync(int id) {
        User user = await _context.Users.FindAsync(id)
            ?? throw new KeyNotFoundException();

        return user;
    }

    public async Task<IEnumerable<User>> GetUsersAsync(string? query) {
        var users = GetAllUsers();
        
        if (!string.IsNullOrEmpty(query)) SearchUsersByFullName(query, users);

        return await users.ToListAsync();
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

        _context.Add(user);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(int id, UpdateUserDto data) {
        User user = await GetUserByIdAsync(id)
            ?? throw new KeyNotFoundException();

        _context.Entry(user).CurrentValues.SetValues(data);
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id) {
        User user = await _context.Users.FindAsync(id)
            ?? throw new KeyNotFoundException();

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }

    private IQueryable<User> GetAllUsers() {
        return from user in _context.Users
            select user;
    }

    private static void SearchUsersByFullName(string query, IQueryable<User> users) {
        string formattedQuery = query.ToUpper();

        users = users.Where(user => $"{user.FirstName} {user.LastName}".Contains(formattedQuery, StringComparison.CurrentCultureIgnoreCase));
    }
}