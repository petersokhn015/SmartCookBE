using Microsoft.EntityFrameworkCore;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Domain.DBEntities;
using SmartCook.Infrastructure.DBManipulation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Infrastructure.DBManipulation.Repositories
{
    public class PreferencesRepository : IPreferencesRepository
    {
        private readonly ApplicationDBContext _context;
        public PreferencesRepository(ApplicationDBContext context)
        {
            _context= context;
        }

        public async Task<Preferences> GetUserPreferences(string email)
        {
            User? user = await _context.Users
                .Include(p => p.UserPreferences)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || user.IsLoggedIn == false)
            {
                return null;
            }

            return user.UserPreferences;
        }

        public async Task<bool> ModifyPreferences(Preferences userPreferences, string email)
        {
            User? user = await _context.Users
                .Include(p => p.UserPreferences)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || user.IsLoggedIn == false) 
            {
                return false;
            }

            user.UserPreferences = userPreferences;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
