using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Identity.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dayana.Shared.Domains.Identity.Claims;

public class Claim : BaseDomain
{
    public string Value { get; set; }

    #region Navigations
    public int UserId { get; set; }

    public User User { get; set; }

    #endregion
}

public class ClaimEntityConfiguration : IEntityTypeConfiguration<Claim>
{
    public void Configure(EntityTypeBuilder<Claim> builder)
    {
        builder.HasKey(x => x.Id);

        #region Mappings

        builder.Property(b => b.Value)
        .HasMaxLength(Defaults.LongLength1)
            .IsRequired();

        #endregion

        #region Navigations

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Claims)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}