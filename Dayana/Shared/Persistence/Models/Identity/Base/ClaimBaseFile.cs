using Dayana.Shared.Persistence.Models.Identity.Base.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Identity.Base;

public class ClaimModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Value { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserModel User { get; set; }

}