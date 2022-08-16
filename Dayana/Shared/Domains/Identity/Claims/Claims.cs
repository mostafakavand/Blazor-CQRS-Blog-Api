using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Domains.Identity.Claims;

internal class Claims : BaseDomain
{
    public int UserId { get; set; }
    public string Value { get; set; }

    #region Navigations

    public User User { get; set; }

    #endregion
}

