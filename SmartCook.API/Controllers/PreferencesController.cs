using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.DTO;
using SmartCook.Domain.DBEntities;

namespace SmartCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly IPreferencesService _preferencesService;
        public PreferencesController(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        [HttpGet("GetUserPreferences")]
        public async Task<ActionResult<PreferencesDTO>> GetUserPreferences(string email)
        {
            PreferencesDTO preferences = await _preferencesService.GetUserPreferences(email);
            if(preferences == null)
            {
                return NotFound("Couldn't fetch preferences, user not found");
            }
            return Ok(preferences);
        }

        [HttpPost("ModifyUserPreferences")]
        public async Task<ActionResult<bool>> ModifyUserPreferences([FromBody] PreferencesDTO preferencesDTO, string email)
        {
            bool isModifiedSuccess = await _preferencesService.ModifyPreferences(preferencesDTO, email);
            if (!isModifiedSuccess)
            {
                return BadRequest("Update preferences failed");
            }
            return Ok("Preferences Updated successfully");
        }
    }
}
