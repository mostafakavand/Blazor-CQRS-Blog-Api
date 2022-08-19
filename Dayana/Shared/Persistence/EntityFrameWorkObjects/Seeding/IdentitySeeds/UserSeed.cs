using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Domains.Identity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.Seeding.IdentitySeeds;

public static class UserSeed
{
    public static List<User> All => new List<User>()
    {
        new User()
        {
            Id = 1,
            IsMobileConfirmed = false,
            IsEmailConfirmed = false,
            Email = "mohammadJavadtabari1024@outlook.com",
            Mobile = "09301724389",
            State = UserState.Active,
            Username = "Illegible_Owner",
            PasswordHash = PasswordHasher.Hash("owner"),
            ConcurrencyStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength),
            SecurityStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength),
            LastPasswordChangeTime = DateTime.Now,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }
    };



    public static void Run(IServiceScope scope)
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var userSeeds = All;
        var seedUsernames = userSeeds.ConvertAll(x => x.Username.ToLower());

        var toBeUpdatedUsers = context.Users
            .Include(x => x.UserRoles)
            .Include(x => x.Claims)
            .Where(x => seedUsernames.Contains(x.Username.ToLower()))
            .ToList();

        var toBeAddedUsers = userSeeds
            .Where(x => !toBeUpdatedUsers.ConvertAll(y => y.Username.ToLower()).Contains(x.Username));

        foreach (var item in toBeUpdatedUsers)
        {
            var seed = userSeeds.Single(x => x.Username.ToLower() == item.Username.ToLower());

            item.IsEmailConfirmed = seed.IsEmailConfirmed;
            item.IsMobileConfirmed = seed.IsMobileConfirmed;
            item.Email = seed.Email;
            item.Mobile = seed.Mobile;
            item.State = seed.State;
            item.PasswordHash = seed.PasswordHash;
            item.ConcurrencyStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength);
            item.SecurityStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength);
            item.UpdatedAt = DateTime.UtcNow;
        }

        foreach (var item in toBeAddedUsers)
        {
            context.Users.Add(item);
        }
    }
}