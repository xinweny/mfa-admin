using MfaApi.Modules.Address;
using MfaApi.Modules.Member;
using Microsoft.IdentityModel.Tokens;

namespace MfaApi.Modules.Membership;

public static class MembershipMapper {
    public static GetMembershipResponse ToGetMembershipResponse(this MembershipModel membership) {
        return new GetMembershipResponse {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            Members = membership.Members?.Select(m => new GetMembershipResponse.MemberDto {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName
            }).ToList(),
            AddressId = membership.AddressId,
            Address = membership.Address?.ToAddressDto(),
            StartDate = membership.StartDate,
            CreatedAt = membership.CreatedAt,
            UpdatedAt = membership.UpdatedAt,
        };
    }

    public static GetMembershipsResponse ToGetMembershipsResponse(this MembershipModel membership) {
        return new GetMembershipsResponse {
            Id = membership.Id,
            MembershipType = membership.MembershipType,
            Members = membership.Members.Select(m => new GetMembershipsResponse.MemberDto {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName
            }).ToList(),
            AddressId = membership.AddressId,
            Address = membership.Address?.ToAddressDto(),
            StartDate = membership.StartDate,
            CreatedAt = membership.CreatedAt,
            UpdatedAt = membership.UpdatedAt,
            Due = membership.Dues.Select(d => new GetMembershipsResponse.DueDto {
                Id = d.Id,
                Year = d.Year,
                AmountPaid = d.AmountPaid,
                PaymentMethod = d.PaymentMethod,
                PaymentDate = d.PaymentDate,
            }).FirstOrDefault(),
        };
    }

    public static MembershipModel ToMembership(this CreateMembershipRequest req) {
        MembershipModel membership = new MembershipModel {
            MembershipType = req.MembershipType,
            StartDate = DateOnly.FromDateTime(req.StartDate),
        };

        var addressDto = req.Address;

        if (addressDto != null) {
            var address = new AddressModel {
                Line1 = addressDto.Line1,
                Line2 = addressDto.Line2,
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
                JoinedDate = DateOnly.FromDateTime(member.JoinedDate),
            }).ToList();
        }

        return membership;
    }
}