using Mfa.Dtos;
using Mfa.Models;

namespace Mfa.Mappers;

public static class MembershipMapper {
    public static GetMembershipResponse ToGetMembershipResponse(this Membership membership) {
        return new GetMembershipResponse {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            Members = membership.Members?.Select(m => new GetMembershipResponse.MemberDto {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName
            }),
            AddressId = membership.AddressId,
            Address = membership.Address?.ToAddressDto(),
            CreatedAt = membership.CreatedAt,
            UpdatedAt = membership.UpdatedAt,
        };
    }

    public static GetMembershipsResponse ToGetMembershipsResponse(this Membership membership) {
        return new GetMembershipsResponse {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            Members = membership.Members?.Select(m => new GetMembershipsResponse.MemberDto {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName
            }),
            AddressId = membership.AddressId,
            Address = membership.Address?.ToAddressDto(),
            CreatedAt = membership.CreatedAt,
            UpdatedAt = membership.UpdatedAt,
        };
    }

    public static Membership ToMembership(this CreateMembershipRequest req) {
        Membership membership = new Membership {
            MembershipType = req.MembershipType,
        };

        var addressDto = req.Address;

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

        if (req.Members != null) {
            membership.Members = req.Members.Select(member => new Member {
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