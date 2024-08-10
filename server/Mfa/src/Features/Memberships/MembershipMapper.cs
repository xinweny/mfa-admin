using Mfa.Dtos;
using Mfa.Models;

namespace Mfa.Mappers;

public static class MembershipMapper {
    public static UserMembershipDto ToUserMembershipDto(this Membership membership) {
        return new UserMembershipDto {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            AddressId = membership.AddressId,
            Address = membership.Address.ToAddressDto(),
            Users = membership.Users.Select(user => user.ToMembershipUsersDto()),
        }; 
    }
}