using Microsoft.AspNetCore.Mvc;
using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Domain.Models;

namespace DigitalCatalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
       
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Login(LoginDto request)
        {
            var response = await _authService.Login(request.Username, request.Password);
            
            if (!response.Success)
            {
                return BadRequest(response);
            }
            
            return Ok(response);
        }
    }
 }
