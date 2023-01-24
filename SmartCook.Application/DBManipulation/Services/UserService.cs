using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.DTO;
using SmartCook.Application.Mediator.Commands.DBManipulation;
using SmartCook.Application.Mediator.Queries.DBManipulation;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            User user = await _mediator.Send(new GetUserByEmailQuery(email));
            if (user == null)
            {
                return null;
            }
            var mappedUser = _mapper.Map<UserDTO>(user);
            return mappedUser;
        }

        public async Task<bool> LoginUser(LoginUserDTO loginUserDTO)
        {
            User user = _mapper.Map<User>(loginUserDTO);
            bool isLoggedInSuccess = await _mediator.Send(new LoginUserCommand(user));
            return isLoggedInSuccess;
        }

        public async Task<bool> LogoutUser(string email)
        {
            bool isLoggedOutSuccess = await _mediator.Send(new LogoutUserCommand(email));
            return isLoggedOutSuccess;
        }

        public async Task<bool> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            User user = _mapper.Map<User>(registerUserDTO);
            bool isRegistrationSuccess = await _mediator.Send(new RegisterUserCommand(user));
            return isRegistrationSuccess;
        }

        public async Task<UserDTO> UpdateUserInfo(string email, string username, IFormFile image)
        {
            User user = await _mediator.Send(new ModifyUserInfoCommand(email, username, image));
            if(user == null)
            {
                return null;
            }
            return _mapper.Map<UserDTO>(user);
        }
    }
}
