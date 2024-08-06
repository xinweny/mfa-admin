using AutoMapper;
using Mfa.Dtos;
using Mfa.Models;

namespace Mfa.Profiles;

public class UserProfile: Profile {
    public UserProfile() {
        CreateMap<User, CreateUserRequestDto>();
    }
}