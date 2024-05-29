using DigitalCatalog.Application.Dtos.Article;
using DigitalCatalog.Application.Dtos.Faculty;
using DigitalCatalog.Application.Dtos.Group;
using DigitalCatalog.Application.Dtos.Role;
using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Application.Services;
using DigitalCatalog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCatalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetUserProfileDto>>>> AddUser(AddUserDto user)
        {
            var response = await _userService.AddUser(user);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-all-users")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetUserProfileDto>>>> GetAllUsers()
        {
            var response = await _userService.GetAllUsers();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-all-faculties")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetFacultyDto>>>> GetAllFaculties()
        {
            var response = await _userService.GetAllFaculties();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-all-groups")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetGroupDto>>>> GetAllGroups()
        {
            var response = await _userService.GetAllGroups();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-all-roles")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetRoleDto>>>> GetAllRoles()
        {
            var response = await _userService.GetAllRoles();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
