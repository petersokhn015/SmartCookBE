using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Firebase.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> Login(string email, string password);

        Task<string> Register(string email, string password, string username);
    }
}
