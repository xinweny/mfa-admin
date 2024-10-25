using Bogus;

namespace MfaApi.Modules.Membership;

public class MembershipFaker: Faker<MembershipModel> {
    public MembershipFaker() {
        RuleFor(m => m.Id, f => f.Random.Guid());
        RuleFor(m => m.MembershipType, f => f.PickRandomWithout([MembershipType.Honorary]));
    }
}