using Bogus;

using MfaApi.Common.Constants;

namespace MfaApi.Modules.Membership;

public class MembershipFaker: Faker<MembershipModel> {
    public MembershipFaker() {
        RuleFor(m => m.Id, f => f.Random.Guid());
        RuleFor(m => m.MembershipType, f => f.PickRandom<MembershipType>());
        RuleFor(
            m => m.StartDate,
            f => DateOnly.FromDateTime(f.Date.Between(new DateTime(MfaConstants.MfaFoundingYear, 1, 1), DateTime.UtcNow))
        );
    }
}