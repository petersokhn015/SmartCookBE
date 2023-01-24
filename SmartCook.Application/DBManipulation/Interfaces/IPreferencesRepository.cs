using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Interfaces
{
    public interface IPreferencesRepository
    {
        Task<Preferences> GetUserPreferences(string email);
        Task<bool> ModifyPreferences(Preferences userPreferences, string email);
    }
}
