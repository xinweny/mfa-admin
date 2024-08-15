using Mfa.Dtos;
using Mfa.Models;

namespace Mfa.Mappers;

public static class MembershipMapper {
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
        Membership membership = new Membership {
            MembershipType = dto.MembershipType,
        };

        var address = dto.Address;

        if (address != null) {
            membership.Address = new Address {
                MembershipId = membership.Id,
                Line1 = address.Line1,
                Line2 = address.Line2,
                Line3 = address.Line3,
                City = address.City,
                PostalCode = address.PostalCode,
                Province = address.Province,
            };
        }

        if (dto.Members != null) {
            membership.Members = dto.Members.Select(member => new Member {
                MembershipId = membership.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                PhoneNumber = member.PhoneNumber,
                Email = member.Email,
                Title = member.Title,
            }).ToList();
        }

        return membership;
    }
}