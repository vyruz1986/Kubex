using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Kubex.DTO;

namespace Kubex.BLL.Services.Interfaces
{
    public interface IUserService
    {
         Task<UserToReturnDTO> GetUserAsync(string userName);
         Task<IEnumerable<UserToReturnDTO>> GetUsersAsync(ClaimsPrincipal requestingUser);
         Task<UserToReturnDTO> AddRoleToUserAsync(ModifyRolesDTO dto);
         Task<UserToReturnDTO> AddRolesToUserAsync(ModifyRolesDTO dto);
         Task<UserToReturnDTO> RemoveRoleFromUserAsync(ModifyRolesDTO dto);
         Task<UserToReturnDTO> RemoveRolesFromUserAsync(ModifyRolesDTO dto);
         Task<UserToReturnDTO> Register(UserRegisterDTO dto);
         Task<UserToReturnDTO> Login(UserLoginDTO dto);
         Task<string> GenerateJWTToken(UserLoginDTO dto);
    }
}