using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Mappers;

public static class MemberMapper {
    public static GetMemberResponse ToGetMemberResponse(this Member member) {
        var membership = member.Membership;

        return new GetMemberResponse {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            PhoneNumber = member.PhoneNumber,
            Email = member.Email,
            Title = member.Title,
            MembershipId = member.MembershipId,
            Membership = new GetMemberResponse.MembershipDto {
                Id = membership.Id,
                MembershipType = membership.MembershipType,
                AddressId = membership.AddressId,
                Address = membership.Address?.ToAddressDto(),
                Members = membership.Members?.Select(m => new GetMemberResponse.MembershipDto.MemberDto {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                }) ?? [],
            },
        };
    }

    public static Member ToMember(this CreateMemberRequest dto) {
        return new Member {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Title = dto.Title,
            MembershipId = dto.MembershipId,
        };
    }

    public static GetMembersResponse ToGetMembersResponse(this Member member) {
        var membership = member.Membership;

        return new GetMembersResponse {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            PhoneNumber = member.PhoneNumber,
            Email = member.Email,
            Title = member.Title,
            MembershipId = member.MembershipId,
            Membership = new GetMembersResponse.MembershipDto {
                Id = membership.Id,
                MembershipType = membership.MembershipType,
                AddressId = membership.AddressId,
                Address = membership.Address?.ToAddressDto(),
            },
        };
    }
}