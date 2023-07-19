using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Commands.Firebase
{
    public record RegisterCommand(string email, string password, string username) : IRequest<string>;
}
