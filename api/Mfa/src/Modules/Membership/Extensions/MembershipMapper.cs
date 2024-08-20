using Mfa.Modules.Address;
using Mfa.Modules.Member;
using Microsoft.IdentityModel.Tokens;

namespace Mfa.Modules.Membership;

public static class MembershipMapper {
    public static GetMembershipResponse ToGetMembershipResponse(this MembershipModel membership) {
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

    public static GetMembershipsResponse ToGetMembershipsResponse(this MembershipModel membership) {
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

    public static MembershipModel ToMembership(this CreateMembershipRequest req) {
        MembershipModel membership = new MembershipModel {
            MembershipType = req.MembershipType,
        };

        var addressDto = req.Address;

        if (addressDto != null) {
            var address = new AddressModel {
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

        if (!req.Members.IsNullOrEmpty()) {
            membership.Members = req.Members.Select(member => new MemberModel {
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