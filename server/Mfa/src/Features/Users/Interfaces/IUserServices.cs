using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IUserServices {
    Task<IEnumerable<User>> GetUsersAsync(string? query);
    Task<User> GetUserByIdAsync(int id);
    Task CreateUserAsync(CreateUserDto data);
    Task UpdateUserAsync(int id, UpdateUserDto data);
    Task DeleteUserAsync(int id);
}