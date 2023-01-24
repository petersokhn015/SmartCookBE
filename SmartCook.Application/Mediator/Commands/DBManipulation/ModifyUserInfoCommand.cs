using MediatR;
using Microsoft.AspNetCore.Http;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Commands.DBManipulation
{
    public record ModifyUserInfoCommand(string email, string username, IFormFile image) : IRequest<User>;
    
}
