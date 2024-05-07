using DigitalCatalog.Dal.DataContext;
using DigitalCatalog.Domain.Interfaces.Repositories;
using DigitalCatalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Dal.Repository
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly DatabaseContext _context;
        private readonly IUserRepository _userRepository;

        public ScoreRepository(DatabaseContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Score>> GetAcademicRecordByUserId(int userId)
        {
            return await _context.Scores
                .Where(s => s.StudentId == userId)
                .Include(s => s.Course)
                .ThenInclude(c => c.Teacher)
                .ToListAsync() ??
                throw new KeyNotFoundException("No course assigned for this student.");
        }
    }
}
