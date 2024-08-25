using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfaApi.Modules.Member;

public class MemberConfiguration: IEntityTypeConfiguration<MemberModel>
{
    public void Configure(EntityTypeBuilder<MemberModel> builder)
    {
        builder
            .HasOne(member => member.Membership)
            .WithMany(membership => membership.Members)
            .HasForeignKey(member => member.MembershipId);

        builder
            .HasMany(member => member.BoardPositions)
            .WithOne(boardPosition => boardPosition.Member)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(boardPosition => boardPosition.MemberId);
        
        builder
            .HasMany(member => member.Exchanges)
            .WithOne(exchange => exchange.Member)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(host => host.MemberId);
    }
}