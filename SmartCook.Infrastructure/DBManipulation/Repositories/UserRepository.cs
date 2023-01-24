using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.DTO;
using SmartCook.Domain.DBEntities;
using SmartCook.Infrastructure.CloudinaryPhoto.Interface;
using SmartCook.Infrastructure.DBManipulation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Infrastructure.DBManipulation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ICloudinaryPhotoService _cloudinaryPhotoService;

        public UserRepository(ApplicationDBContext context, ICloudinaryPhotoService cloudinaryPhotoService)
        {
            _context = context;
            _cloudinaryPhotoService = cloudinaryPhotoService;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            if(_context.Users.Where(u => u.Email == email && u.IsLoggedIn == true).Any())
            {
                User? user = await _context.Users
                    .Include(p => p.UserPreferences)
                    .Include(f => f.FavoriteRecipes)
                    .FirstOrDefaultAsync(u => u.Email == email && u.IsLoggedIn == true);
                return user!;
            }
            return null;
        }

        public async Task<bool> LoginUser(User user)
        {
            if (!await _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).AnyAsync())
            {
                return false;
            }

            User? loginUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
            loginUser!.IsLoggedIn = true;
            _context.Users.Update(loginUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LogoutUser(string email)
        {
            if (!await _context.Users.Where(u => u.Email == email).AnyAsync())
            {
                return false;
            }

            User? logoutUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            logoutUser!.IsLoggedIn = false;
            _context.Users.Update(logoutUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> ModifyUserInfo(string email, string username, IFormFile image)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user!.ImageUrl != "")
                {
                    await _cloudinaryPhotoService.DeletePhotoAsync(user!.ImageUrl);
                }

                var result = await _cloudinaryPhotoService.AddPhotoAsync(image);
                user!.Username = username;
                user!.ImageUrl = result.SecureUrl.ToString();

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            if(await _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).AnyAsync())
            {
                return false;
            }

            user.IsLoggedIn = false;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
