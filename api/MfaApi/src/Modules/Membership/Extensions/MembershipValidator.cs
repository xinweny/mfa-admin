using FluentValidation;

using MfaApi.Modules.Address;
using MfaApi.Modules.Member;
using MfaApi.Common.Constants;

namespace MfaApi.Modules.Membership;

public class MembershipValidator: AbstractValidator<MembershipModel> {
    public MembershipValidator() {
        RuleFor(m => m.MembershipType)
            .IsInEnum()
                .WithMessage("Invalid membership type.");

        RuleFor(m => m.Members)
            .Cascade(CascadeMode.Stop)
            .Must(members => members?.Count > 0)
                .WithMessage("At least 1 member is required.")
            .Must(members => members?.Count == 1)
                .When(m => m.MembershipType == MembershipType.Single, ApplyConditionTo.CurrentValidator)
                .WithMessage("Single memberships must only have 1 member.")
            .Must(members => members?.Count <= MfaConstants.MaxFamilyMembershipMembers)
                .When(m => m.MembershipType == MembershipType.Family, ApplyConditionTo.CurrentValidator)
                .WithMessage($"Family memberships cannot exceed {MfaConstants.MaxFamilyMembershipMembers} members.")
            .Must(members => members?.Count <= MfaConstants.MaxHonoraryMembershipMembers)
                .When(m => m.MembershipType == MembershipType.Honorary, ApplyConditionTo.CurrentValidator)
                .WithMessage($"Honorary memberships cannot exceed {MfaConstants.MaxHonoraryMembershipMembers} members.");

        RuleForEach(m => m.Members)
            .SetValidator(new MemberValidator());

        RuleFor(m => m.Address)
            .SetValidator(new AddressValidator()!)
                .When(m => m.Address != null);
    }
}