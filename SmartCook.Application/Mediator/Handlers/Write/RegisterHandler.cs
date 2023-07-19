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
    public class RegisterHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IAuthenticationRepository _repository;

        public RegisterHandler(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return _repository.Register(request.email, request.password, request.username);
        }
    }
}
