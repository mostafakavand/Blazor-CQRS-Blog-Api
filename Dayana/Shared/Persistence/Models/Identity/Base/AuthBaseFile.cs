using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Identity.Base;

public class LoginResult
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

public class TokenResult
{
    public string AccessToken { get; set; }
}