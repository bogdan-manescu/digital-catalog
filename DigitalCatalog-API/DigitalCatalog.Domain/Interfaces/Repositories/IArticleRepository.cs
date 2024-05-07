using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Domain.Interfaces.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> CreateArticle(Article article);
        Task<IEnumerable<Article>> GetArticles();
    }
}
