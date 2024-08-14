using Mfa.Dtos;
using Mfa.Models;

namespace Mfa.Mappers;

public static class MembershipMapper {
    public static MemberMembership ToMemberMembership(this Membership membership) {
        return new MemberMembership {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            AddressId = membership.AddressId,
            Address = membership.Address?.ToAddressDto(),
            Members = membership.Members?.Select(member => member.ToMembershipMember()) ?? [],
        }; 
    }

    public static MembersMembership ToMembersMembership(this Membership membership) {
        return new MembersMembership {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            AddressId = membership.AddressId,
            Address = membership.Address?.ToAddressDto(),
        }; 
    }

    public static GetMembershipResponse ToGetMembershipResponse(this Membership membership) {
        return new GetMembershipResponse {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            AddressId = membership.AddressId,
            Address = membership.Address?.ToAddressDto(),
            CreatedAt = membership.CreatedAt,
            UpdatedAt = membership.UpdatedAt,
        };
    }

    public static Membership ToMembership(this CreateMembershipRequest dto) {
        return new Membership {
            MembershipType = dto.MembershipType,
            AddressId = dto.AddressId,
        };
    }
}