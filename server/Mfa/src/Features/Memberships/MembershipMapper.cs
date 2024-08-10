using Mfa.Dtos;
using Mfa.Models;

namespace Mfa.Mappers;

public static class MembershipMapper {
    public static MemberMembershipDto ToMemberMembershipDto(this Membership membership) {
        return new MemberMembershipDto {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            AddressId = membership.AddressId,
            Address = membership.Address.ToAddressDto(),
            Members = membership.Members.Select(member => member.ToMembershipMembersDto()),
        }; 
    }

    public static MembersMembershipDto ToMembersMembershipDto(this Membership membership) {
        return new MembersMembershipDto {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            AddressId = membership.AddressId,
            Address = membership.Address.ToAddressDto(),
        }; 
    }
}