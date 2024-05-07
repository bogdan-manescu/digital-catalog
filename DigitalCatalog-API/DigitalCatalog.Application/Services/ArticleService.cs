using AutoMapper;
using DigitalCatalog.Application.Dtos.Article;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Domain.Interfaces.Repositories;
using DigitalCatalog.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper, IConfiguration configuration)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<IEnumerable<GetArticleDto>>> CreateArticle(CreateArticleDto article)
        {
            var response = new ServiceResponse<IEnumerable<GetArticleDto>>();
            var articles = await _articleRepository.CreateArticle(_mapper.Map<Article>(article));

            response.Data = _mapper.Map<IEnumerable<GetArticleDto>>(articles);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetArticleDto>>> GetArticles()
        {
            var response = new ServiceResponse<IEnumerable<GetArticleDto>>();
            var articles = await _articleRepository.GetArticles();

            response.Data = _mapper.Map<IEnumerable<GetArticleDto>>(articles);

            return response;
        }
    }
}
