using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Claims;
using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.Seeding.IdentitySeeds;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects;

public sealed class AppDbContext : DbContext
{
    #region Identity DbSets

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Claim> Claims { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    #endregion

    #region Blog DbSets
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public DbSet<PostIssue> PostIssues { get; set; }
    public DbSet<PostCategoryIssue> PostCategoryIssues { get; set; }
    public DbSet<PostComment> PostComments { get; set; }
    public DbSet<PostCategoryIssueComment> PostCategoryIssueComments { get; set; }
    public DbSet<PostIssueComment> PostIssueComments { get; set; }
    #endregion

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        modelBuilder.Entity<UserRole>().HasData(UserRoleSeed.All);
        modelBuilder.Entity<Role>().HasData(RoleSeed.All);
        modelBuilder.Entity<User>().HasData(UserSeed.All);
        modelBuilder.Entity<Permission>().HasData(PermissionSeed.All);
        modelBuilder.Entity<RolePermission>().HasData(RolePermissionSeed.All);
        // Creating Model
        base.OnModelCreating(modelBuilder);
    }
}