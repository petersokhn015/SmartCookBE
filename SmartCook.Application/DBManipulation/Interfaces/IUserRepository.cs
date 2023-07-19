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
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<bool> LoginUser(User user);
        //Task<bool> LogoutUser(string email);
        Task<User> ModifyUserInfo(string email, string username, IFormFile image);
        Task<bool> RegisterUser(User user);
    }
}
