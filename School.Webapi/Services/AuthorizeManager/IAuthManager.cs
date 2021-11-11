using School.Webapi.Entities.DTOs.UserDTOs;
using System.Threading.Tasks;

namespace School.Webapi.Services.AuthorizeManager
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO userDto);
        Task<string> CreateToken();
    }
}
