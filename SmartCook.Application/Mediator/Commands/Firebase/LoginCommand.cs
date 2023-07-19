using MediatR;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Commands.Firebase
{
    public record LoginCommand(string email, string password) : IRequest<string>;
}
