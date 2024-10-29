using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MfaApi.Modules.Due;

public class DueConfiguration : IEntityTypeConfiguration<DueModel>
{
    public void Configure(EntityTypeBuilder<DueModel> builder)
    {
        builder
            .HasIndex(d => new {
                d.MembershipId,
                d.Year,
            })
            .IsUnique();
    }
}