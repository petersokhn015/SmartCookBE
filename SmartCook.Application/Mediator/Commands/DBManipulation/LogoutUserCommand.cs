using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Commands.DBManipulation
{
    public record LogoutUserCommand(string email) : IRequest<bool>;
}
