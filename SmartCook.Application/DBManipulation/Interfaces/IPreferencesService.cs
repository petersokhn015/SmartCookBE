using SmartCook.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Interfaces
{
    public interface IPreferencesService
    {
        Task<PreferencesDTO> GetUserPreferences(string email);
        Task<bool> ModifyPreferences(PreferencesDTO preferencesDTO, string email);
    }
}
