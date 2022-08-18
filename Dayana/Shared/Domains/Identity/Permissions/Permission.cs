using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Identity.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Domains.Identity.Permissions;

internal class Permission: BaseDomain
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Value { get; set; }

    #region Navigations

    public ICollection<RolePermission> Roles { get; set; }

    #endregion
}

internal class PermissionEntityConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(x => x.Id);

        #region Mappings

        builder.Property(b => b.Value)
            .HasMaxLength(Defaults.NameLength)
            .IsRequired();

        builder.Property(b => b.Name)
            .HasMaxLength(Defaults.TitleLength);

        #endregion
    }
}