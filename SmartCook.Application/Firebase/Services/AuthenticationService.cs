using MediatR;
using SmartCook.Application.Firebase.Interfaces;
using SmartCook.Application.Mediator.Commands.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Firebase.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMediator _mediator;

        public AuthenticationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Login(string email, string password)
        {
            return await _mediator.Send(new LoginCommand(email, password));
        }

        public async Task<string> Register(string email, string password, string username)
        {
            return await _mediator.Send(new RegisterCommand(email, password, username));
        }
    }
}
