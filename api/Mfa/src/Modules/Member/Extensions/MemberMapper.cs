using Mfa.Modules.Address;

namespace Mfa.Modules.Member;

public static class MemberMapper {
    public static GetMemberResponse ToGetMemberResponse(this MemberModel member) {
        var membership = member.Membership;
        
        return new GetMemberResponse {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            PhoneNumber = member.PhoneNumber,
            Email = member.Email,
            JoinedDate = member.JoinedDate,
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

    public static MemberModel ToMember(this CreateMemberRequest req) {
        return new MemberModel {
            FirstName = req.FirstName,
            LastName = req.LastName,
            PhoneNumber = req.PhoneNumber,
            Email = req.Email,
            MembershipId = req.MembershipId,
            JoinedDate = req.JoinedDate,
        };
    }

    public static GetMembersResponse ToGetMembersResponse(this MemberModel member) {
        var membership = member.Membership;

        return new GetMembersResponse {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            PhoneNumber = member.PhoneNumber,
            Email = member.Email,
            JoinedDate = member.JoinedDate,
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