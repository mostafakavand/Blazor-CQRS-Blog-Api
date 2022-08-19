using AutoMapper;
using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Persistence.Models.Identity.Base.Claims;
using Dayana.Shared.Persistence.Models.Identity.Base.Permissions;
using Dayana.Shared.Persistence.Models.Identity.Base.Roles;
using Dayana.Shared.Persistence.Models.Identity.Base.Users;
using System.Security.Claims;

namespace Dayana.Shared.Persistence.AutoMapperProfile;

public class IdentityAutoMapperProfiles : Profile
{
    public IdentityAutoMapperProfiles()
    {
        CreateMap<PermissionModel, Permission>().ReverseMap();

        CreateMap<RoleModel, Role>().ReverseMap();

        CreateMap<UserModel, User>().ReverseMap();

        CreateMap<UserRoleModel, UserRole>().ReverseMap();

        CreateMap<RolePermissionModel, RolePermission>().ReverseMap();

        CreateMap<ClaimModel, Claim>().ReverseMap();
    }
}