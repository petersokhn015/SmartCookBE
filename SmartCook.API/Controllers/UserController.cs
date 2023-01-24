using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCook.API.Validators;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.DTO;
using SmartCook.Domain.DBEntities;

namespace SmartCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private RegisterUserValidator _registerUserValidator;
        private LoginUserValidator _loginUserValidator;
        public UserController(IUserService userService)
        {
            _userService = userService;
            _registerUserValidator = new();
            _loginUserValidator = new();
        }

        [HttpGet("GetUserByEmail")]
        public async Task<ActionResult<UserDTO>> GetUserByEmail(string email)
        {

            UserDTO user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound("The user doesn't exist");
            }
            return Ok(user);
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDTO registerUserDTO)
        {
            var results = _registerUserValidator.Validate(registerUserDTO);
            if (!results.IsValid)
            {
                string errors = "";
                foreach (ValidationFailure failure in results.Errors)
                {
                    errors += $"{failure.PropertyName}: {failure.ErrorMessage} \n";
                }
                return BadRequest(errors);
            }

            bool isRegistrationSuccess = await _userService.RegisterUser(registerUserDTO);
            if (!isRegistrationSuccess)
            {
                return BadRequest("The user already exists");
            }
            return Ok(registerUserDTO);

        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult> LoginUser([FromBody] LoginUserDTO loginUserDTO)
        {
            var results = _loginUserValidator.Validate(loginUserDTO);
            if (!results.IsValid)
            {
                string errors = "";
                foreach (ValidationFailure failure in results.Errors)
                {
                    errors += $"{failure.PropertyName}: {failure.ErrorMessage} \n";
                }
                return BadRequest(errors);
            }

            bool isLoggedInSuccessfully = await _userService.LoginUser(loginUserDTO);
            if (!isLoggedInSuccessfully)
            {
                return NotFound("The user doesn't exist");
            }
            return Ok(loginUserDTO);
        }

        [HttpPost("LogoutUser")]
        public async Task<ActionResult> LogoutUser(string email)
        {
            bool isLoggedOutSuccess = await _userService.LogoutUser(email);

            if(!isLoggedOutSuccess)
            {
                return NotFound("the user doesn't exist");
            }
            return Ok("User logged out");
        }

        [HttpPost("UpdateUserInfo")]
        public async Task<ActionResult> UpdateUserInfo(string email, string username, IFormFile image)
        {
            User user = await _userService.UpdateUserInfo(email, username, image);
            if(user == null)
            {
                return BadRequest("Couldn't update user information");
            }
            return Ok(user);
        }

    }
}
