using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IUserServices {
    Task<IEnumerable<GetUsersResponseDto>> GetUsers(GetUsersRequestDto dto);
    Task<GetUserResponseDto> GetUserById(int id);
    Task<int> CreateUser(CreateUserRequestDto dto);
    Task UpdateUser(int id, UpdateUserRequestDto dto);
    Task DeleteUser(int id);
}