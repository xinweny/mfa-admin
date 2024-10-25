using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MfaApi.Modules.Membership;

public class MembershipConfiguration : IEntityTypeConfiguration<MembershipModel>
{
    public void Configure(EntityTypeBuilder<MembershipModel> builder)
    {
        builder
            .HasMany(membership => membership.Members)
            .WithOne(member => member.Membership)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(member => member.MembershipId);

        builder
            .HasMany(membership => membership.Dues)
            .WithOne(due => due.Membership)
            .HasForeignKey(due => due.MembershipId);
        
        builder
            .HasOne(membership => membership.Address)
            .WithOne(address => address.Membership)
            .HasForeignKey<MembershipModel>(membership => membership.AddressId);

        builder
            .Property(membership => membership.IsActive)
            .HasDefaultValue(true);
    }
}