using Microsoft.AspNetCore.Http;
using SmartCook.Application.DTO;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByEmail(string email);
        Task<bool> LoginUser(LoginUserDTO loginUserDTO);
        Task<bool> LogoutUser(string email);
        Task<bool> RegisterUser(RegisterUserDTO registerUserDTO);
        Task<User> UpdateUserInfo(string email, string username, IFormFile image);
    }
}
