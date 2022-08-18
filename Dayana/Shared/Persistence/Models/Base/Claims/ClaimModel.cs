using Dayana.Shared.Persistence.Models.Base.Users;

namespace Dayana.Shared.Persistence.Models.Base.Claims;

public class ClaimModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Value { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserModel User { get; set; }

}