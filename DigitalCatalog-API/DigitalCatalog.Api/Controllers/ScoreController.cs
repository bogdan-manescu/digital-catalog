using Azure.Core;
using DigitalCatalog.Application.Dtos.Score;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Application.Services;
using DigitalCatalog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCatalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet("get-academic-record-by-user-id/{userId}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetAcademicRecordDto>>>> GetAcademicRecordByUserId(int userId)
        {
            var response = await _scoreService.GetAcademicRecordByUserId(userId);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
