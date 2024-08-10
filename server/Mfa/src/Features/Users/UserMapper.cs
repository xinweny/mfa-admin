using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Mappers;

public static class UserMapper {
    public static GetUserResponseDto ToGetUserResponseDto(this User user) {
        return new GetUserResponseDto {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Title = user.Title,
            MembershipId = user.MembershipId,
            Membership = user.Membership.ToUserMembershipDto(),
        };
    }

    public static User ToUser(this CreateUserRequestDto dto) {
        return new User {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Title = dto.Title,
            MembershipId = dto.MembershipId,
        };
    }

    public static User ToGetUsersResponseDto(this User user) {
        return new GetUsersResponseDto {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Title = user.Title,
            MembershipId = user.MembershipId,
            Membership = user.Membership,
        };
    }

    public static MembershipUsersDto ToMembershipUsersDto(this User user) {
        return new MembershipUsersDto {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }
}