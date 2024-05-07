using DigitalCatalog.Application.Dtos.Article;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Interfaces
{
    public interface IArticleService
    {
        Task<ServiceResponse<IEnumerable<GetArticleDto>>> CreateArticle(CreateArticleDto article);
        Task<ServiceResponse<IEnumerable<GetArticleDto>>> GetArticles();
    }
}
