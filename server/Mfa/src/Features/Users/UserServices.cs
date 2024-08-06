using AutoMapper;

using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Models;

namespace Mfa.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserServices(IUserRepository userRepository, IMapper mapper) {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateUser(CreateUserRequestDto dto)
    {
        User user = await _userRepository.CreateUser(_mapper.Map<User>(dto));

        return user.Id;
    }

    public async Task DeleteUser(int id)
    {
        User user = await _userRepository.GetUserById(id);

        await _userRepository.DeleteUser(user);
    }

    public async Task<GetUserResponseDto> GetUserById(int id)
    {
        User user = await _userRepository.GetUserById(id);

        return _mapper.Map<GetUserResponseDto>(user);
    }

    public async Task<IEnumerable<GetUsersResponseDto>> GetUsers(GetUsersRequestDto dto)
    {
        return await _userRepository.GetUsers(dto);;
    }

    public async Task UpdateUser(int id, UpdateUserRequestDto dto)
    {
        User user = await _userRepository.GetUserById(id);

        await _userRepository.UpdateUser(user, dto);
    }
}