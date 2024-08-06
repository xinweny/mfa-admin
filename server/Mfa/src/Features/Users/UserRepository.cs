using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Mfa.Data;
using Mfa.Models;
using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Repositories;

public class UserRepository: IUserRepository {
    private readonly MfaDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(MfaDbContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    public async Task<User> GetUserById(int id) {
        User user = await _context.Users.FindAsync(id)
            ?? throw new KeyNotFoundException();

        return user;
    }

    public async Task<IEnumerable<GetUsersResponseDto>> GetUsers(GetUsersRequestDto dto) {
        var users = from user in _context.Users
            select user;

        string? query = dto.Query;
        
        if (!string.IsNullOrEmpty(query)) {
            string formattedQuery = query.ToUpper();

            users = users
                .Where(user => $"{user.FirstName} {user.LastName}".Contains(formattedQuery, StringComparison.CurrentCultureIgnoreCase));
        }

        return await users
            .Select(user => _mapper.Map<GetUsersResponseDto>(user))
            .ToListAsync();
    }

    public async Task<User> CreateUser(User user) {
        _context.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateUser(User user, UpdateUserRequestDto dto) {
        user.UpdatedAt = DateTime.UtcNow;

        _context.Entry(user).CurrentValues.SetValues(dto);
        
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task DeleteUser(User user) {
        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}