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

    public static GetDuesResponse ToGetDuesResponse(this DueModel due) {
        return new GetDuesResponse {
            Id = due.Id,
            MembershipId = due.MembershipId,
            AmountPaid = due.AmountPaid,
            Year = due.Year,
            PaymentMethod = due.PaymentMethod,
            PaymentDate = due.PaymentDate,
        };
    }
}