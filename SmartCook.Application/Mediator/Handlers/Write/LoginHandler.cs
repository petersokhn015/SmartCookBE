using MediatR;
using SmartCook.Application.Firebase.Interfaces;
using SmartCook.Application.Mediator.Commands.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Handlers.Write
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IAuthenticationRepository _repository;

        public LoginHandler(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return _repository.Login(request.email, request.password); 
        }
    }
}
