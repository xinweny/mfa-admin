using FluentValidation;

using Mfa.Modules.Address;
using Mfa.Modules.Member;
using Mfa.Common.Constants;

namespace Mfa.Modules.Membership;

public class MembershipValidator: AbstractValidator<MembershipModel> {
    public MembershipValidator() {
        RuleFor(m => m.MembershipType)
            .IsInEnum()
            .WithMessage("Invalid membership type.");

        RuleFor(m => m.Address)
            .SetValidator(new AddressValidator()!)
            .When(m => m.Address != null);

        RuleFor(m => m.Members)
            .NotEmpty()
            .WithMessage("At least 1 member is required.")
            .Must(members => members!.Count() == 1)
            .When(m => m.MembershipType == MembershipType.Single)
            .WithMessage("Single memberships can only have 1 member.")
            .Must(members => members!.Count() <= MfaConstants.MaxFamilyMembershipMembers)
            .When(m => m.MembershipType == MembershipType.Family)
            .WithMessage($"Family memberships cannot exceed ${MfaConstants.MaxFamilyMembershipMembers} members.")
            .Must(members => members!.Count() <= MfaConstants.MaxHonoraryMembershipMembers)
            .When(m => m.MembershipType == MembershipType.Honorary)
            .WithMessage($"Honorary memberships cannot exceed ${MfaConstants.MaxHonoraryMembershipMembers} members.")
            .ForEach(member => member.SetValidator(new MemberValidator()));
    }
}