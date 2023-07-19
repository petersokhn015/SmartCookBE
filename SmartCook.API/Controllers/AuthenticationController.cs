using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCook.Domain.DBEntities;
using SmartCook.Application.DTO;
using SmartCook.Application.DBManipulation.Services;
using SmartCook.Application.DBManipulation.Interfaces;
using AutoMapper;
using SmartCook.API.Validators;
using FluentValidation.Results;
using Firebase.Auth;
using SmartCook.Application.Firebase.Interfaces;

namespace SmartCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authService;
        private readonly IMapper _mapper;
        private RegisterUserValidator _registerUserValidator;
        private LoginUserValidator _loginUserValidator;
        public AuthenticationController(IUserService userService, IMapper mapper, IAuthenticationService authService)
        {
            _userService = userService;
            _mapper = mapper;
            _registerUserValidator = new();
            _loginUserValidator = new();
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO user)
        {
            try
            {
                var results = _registerUserValidator.Validate(user);
                if (!results.IsValid)
                {
                    string errors = "";
                    foreach (ValidationFailure failure in results.Errors)
                    {
                        errors += $"{failure.PropertyName}: {failure.ErrorMessage} \n";
                    }
                    return BadRequest(errors);
                }

                string authLink = await _authService.Register(user.Email, user.Password, user.Username);
                if (await _userService.LoginUser(_mapper.Map<LoginUserDTO>(user)) == false)
                {
                    await _userService.RegisterUser(user);
                }
                return Ok(authLink);
            }
            catch (FirebaseAuthException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO user)
        {
            try
            {
                var results = _loginUserValidator.Validate(user);
                if (!results.IsValid)
                {
                    string errors = "";
                    foreach (ValidationFailure failure in results.Errors)
                    {
                        errors += $"{failure.PropertyName}: {failure.ErrorMessage} \n";
                    }
                    return BadRequest(errors);
                }

                string authLink = await _authService.Login(user.Email, user.Password);
                bool isLoggedIn = await _userService.LoginUser(user);
                return Ok(authLink);
            }
            catch (FirebaseAuthException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
