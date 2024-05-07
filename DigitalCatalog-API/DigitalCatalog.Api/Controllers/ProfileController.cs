using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCatalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPatch("update-profile")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateProfile(UpdateProfileDto request)
        {
            var response = await _profileService.UpdateProfile(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("update-login-credentials")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateLoginCredentials(UpdateLoginCredentialsDto request)
        {
            var response = await _profileService.UpdateLoginCredentials(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
