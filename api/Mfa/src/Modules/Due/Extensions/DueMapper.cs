namespace Mfa.Modules.Due;

public static class DueMapper {
    public static DueModel ToDue(this CreateDueRequest req) {
        return new DueModel {
            MembershipId = req.MembershipId,
            AmountPaid = req.AmountPaid,
            Year = req.Year,
            PaymentMethod = req.PaymentMethod,
            PaymentDate = req.PaymentDate,
        };
    }

    public static GetMembershipDuesResponse ToGetMembershipDuesResponse(this DueModel due) {
        return new GetMembershipDuesResponse {
            Id = due.Id,
            MembershipId = due.MembershipId,
            AmountPaid = due.AmountPaid,
            Year = due.Year,
            PaymentMethod = due.PaymentMethod,
            PaymentDate = due.PaymentDate,
        };
    }

    public static GetDuesResponse ToGetDuesResponse(this DueModel due) {
        var membership = due.Membership ?? null;

        return new GetDuesResponse {
            Id = due.Id,
            MembershipId = due.MembershipId,
            AmountPaid = due.AmountPaid,
            Year = due.Year,
            PaymentMethod = due.PaymentMethod,
            PaymentDate = due.PaymentDate,
            Membership = membership != null
                ? new GetDuesResponse.MembershipDto {
                    Id = membership.Id,
                    MembershipType = membership.MembershipType,
                    Members = membership.Members?.Select(m => new GetDuesResponse.MembershipDto.MemberDto {
                        Id = m.Id,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                    }) ?? [],
                }
            : null,
        };
    }
}