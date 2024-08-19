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

        var addressDto = dto.Address;

        if (addressDto != null) {
            var address = new Address {
                Line1 = addressDto.Line1,
                Line2 = addressDto.Line2,
                Line3 = addressDto.Line3,
                City = addressDto.City,
                PostalCode = addressDto.PostalCode,
                Province = addressDto.Province,
            };

            membership.Address = address;
            membership.AddressId = address.Id;
        }

        if (dto.Members != null) {
            membership.Members = dto.Members.Select(member => new Member {
                MembershipId = membership.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                PhoneNumber = member.PhoneNumber,
                Email = member.Email,
            }).ToList();
        }

        return membership;
    }
}