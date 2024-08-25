using Bogus;

using MfaApi.Common.Constants;
using MfaApi.Modules.Member;

namespace MfaApi.Modules.Membership;

public class MembershipFaker: Faker<MembershipModel> {
    private readonly Faker<MemberModel> _memberFaker = new MemberFaker();

    public MembershipFaker() {
        RuleFor(m => m.Id, f => f.Random.Guid());
        RuleFor(m => m.MembershipType, f => f.PickRandom<MembershipType>());
        RuleFor(
            m => m.StartDate,
            f => DateOnly.FromDateTime(f.Date.Between(new DateTime(MfaConstants.MfaFoundingYear, 1, 1), DateTime.UtcNow))
        );
        RuleFor(
            m => m.Members,
            (f, m) => {
                var members = m.MembershipType == MembershipType.Single
                    ? _memberFaker.Generate(1)
                    : _memberFaker.GenerateBetween(1, 4);

                foreach (MemberModel member in members) {
                    member.JoinedDate = m.StartDate;
                }

                return members;
            }
        );

    }
}