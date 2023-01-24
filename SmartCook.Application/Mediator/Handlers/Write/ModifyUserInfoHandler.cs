using MediatR;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.Mediator.Commands.DBManipulation;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Handlers.Write
{
    public class ModifyUserInfoHandler : IRequestHandler<ModifyUserInfoCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public ModifyUserInfoHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(ModifyUserInfoCommand request, CancellationToken cancellationToken)
        {
            return _userRepository.ModifyUserInfo(request.email ,request.username, request.image);
        }
    }
}
