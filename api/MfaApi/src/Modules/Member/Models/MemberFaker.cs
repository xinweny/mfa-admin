using Bogus;

namespace MfaApi.Modules.Member;

public class MemberFaker: Faker<MemberModel> {
    public MemberFaker() {
        RuleFor(m => m.Id, f => f.Random.Guid());
        RuleFor(m => m.FirstName, f => f.Name.FirstName());
        RuleFor(m => m.LastName, f => f.Name.LastName());
        RuleFor(m => m.Email, f => f.Internet.Email());
        RuleFor(
            m => m.PhoneNumber,
            f => f.Phone
                .PhoneNumberFormat()
                .Replace("-", "")
        );
    }
}