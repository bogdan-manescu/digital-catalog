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
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Faculty)
                .Include(u => u.Group)
                .FirstOrDefaultAsync(u => u.Username == username) ??
                throw new KeyNotFoundException("User not found.");
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Faculty)
                .Include(u => u.Group)
                .FirstOrDefaultAsync(u => u.Id == id) ??
                throw new KeyNotFoundException("User not found.");
        }
    }
}
