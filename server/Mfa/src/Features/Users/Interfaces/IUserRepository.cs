using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IUserRepository {
    Task<IEnumerable<GetUsersResponseDto>> GetUsers(GetUsersRequestDto dto);
    Task<User> GetUserById(int id);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(User user, UpdateUserRequestDto dto);
    Task DeleteUser(User user);
}