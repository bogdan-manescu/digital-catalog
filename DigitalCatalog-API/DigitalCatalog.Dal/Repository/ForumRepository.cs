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
    public class ForumRepository : IForumRepository
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public ForumRepository(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Comment>> CreateComment(Comment comment)
        {
            if (comment == null) throw new ArgumentNullException("No comment was provided.");

            comment.PostedAt = DateTime.Now;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            var comments = await GetForum();

            return comments;
        }

        public async Task<IEnumerable<Comment>> GetForum()
        {
            return await _context.Comments
                .Include(c => c.User)
                .ThenInclude(u => u.Role)
                .Include(c => c.User)
                .ThenInclude(u => u.Faculty)
                .OrderBy(c => c.PostedAt)
                .ToListAsync();
        }
    }
}
