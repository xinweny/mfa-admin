using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Mappers;

public static class MemberMapper {
    public static GetMemberResponse ToGetMemberResponse(this Member member) {
        return new GetMemberResponse {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            PhoneNumber = member.PhoneNumber,
            Email = member.Email,
            Title = member.Title,
            MembershipId = member.MembershipId,
            Membership = member.Membership.ToMemberMembership(),
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

    public static Member ToMember(this CreateMembershipMember dto, int membershipId) {
        return new Member {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Title = dto.Title,
            MembershipId = membershipId,
        };
    }

    public static GetMembersResponse ToGetMembersResponse(this Member member) {
        return new GetMembersResponse {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            PhoneNumber = member.PhoneNumber,
            Email = member.Email,
            Title = member.Title,
            MembershipId = member.MembershipId,
            Membership = member.Membership.ToMembersMembership(),
        };
    }

    public static MembershipMember ToMembershipMember(this Member member) {
        return new MembershipMember {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
        };
    }
}