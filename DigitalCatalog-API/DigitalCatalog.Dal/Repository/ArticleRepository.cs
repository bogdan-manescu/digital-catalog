using DigitalCatalog.Dal.DataContext;
using DigitalCatalog.Domain.Interfaces.Repositories;
using DigitalCatalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Dal.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public ArticleRepository(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Article>> CreateArticle(Article article)
        {
            if (article == null) throw new ArgumentNullException("No article was provided.");

            article.Created = DateTime.Now;

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            var articles = await GetArticles();

            return articles;
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles
                .OrderByDescending(a => a.Created)
                .Include(a => a.Author)
                .ToListAsync();
        }
    }
}
