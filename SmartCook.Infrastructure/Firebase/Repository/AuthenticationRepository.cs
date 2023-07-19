using Firebase.Auth;
using SmartCook.Application.Firebase.Interfaces;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Infrastructure.Firebase.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly FirebaseAuthProvider _firebaseAuthProvider;
        public AuthenticationRepository()
        {
            _firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyA0RlJugaHwkEzUKTG4uXojdCY2719sUyA"));
        }

        public async Task<string> Login(string email, string password)
        {
            var firebaseAuthLink = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
            string authLink = firebaseAuthLink.FirebaseToken;
            return authLink;
        }

        public async Task<string> Register(string email, string password, string username)
        {
            var firebaseAuthLink = await _firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(email, password, username, sendVerificationEmail: true);
            string authLink = firebaseAuthLink.FirebaseToken;
            return authLink;
        }
    }
}
