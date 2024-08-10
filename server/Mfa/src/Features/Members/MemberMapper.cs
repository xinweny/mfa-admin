using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Mappers;

public static class MemberMapper {
    public static GetMemberResponseDto ToGetMemberResponseDto(this Member member) {
        return new GetMemberResponseDto {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            PhoneNumber = member.PhoneNumber,
            Email = member.Email,
            Title = member.Title,
            MembershipId = member.MembershipId,
            Membership = member.Membership.ToMemberMembershipDto(),
        };
    }

    public static Member ToMember(this CreateMemberRequestDto dto) {
        return new Member {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Title = dto.Title,
            MembershipId = dto.MembershipId,
        };
    }

    public static GetMembersResponseDto ToGetMembersResponseDto(this Member member) {
        return new GetMembersResponseDto {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            PhoneNumber = member.PhoneNumber,
            Email = member.Email,
            Title = member.Title,
            MembershipId = member.MembershipId,
            Membership = member.Membership.ToMembersMembershipDto(),
        };
    }

    public static MembershipMembersDto ToMembershipMembersDto(this Member member) {
        return new MembershipMembersDto {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
        };
    }
}