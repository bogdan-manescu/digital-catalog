using DigitalCatalog.Application.Dtos.Article;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Application.Services;
using DigitalCatalog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCatalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost("create-article")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetArticleDto>>>> CreateArticle(CreateArticleDto article)
        {
            var response = await _articleService.CreateArticle(article);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-articles")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetArticleDto>>>> GetArticles()
        {
            var response = await _articleService.GetArticles();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
