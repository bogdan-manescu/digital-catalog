using DigitalCatalog.Application.Dtos.Forum;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Application.Services;
using DigitalCatalog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCatalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpPost("create-comment")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetCommentDto>>>> CreateComment(CreateCommentDto comment)
        {
            var response = await _forumService.CreateComment(comment);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-forum")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetCommentDto>>>> GetForum()
        {
            var response = await _forumService.GetForum();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
