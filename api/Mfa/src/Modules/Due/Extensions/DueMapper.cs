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

}