using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DigitalCatalog.Dal.DataContext;
using DigitalCatalog.Domain.Interfaces.Repositories;
using DigitalCatalog.Domain.Models;

namespace DigitalCatalog.Dal.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DatabaseContext _context;

        private readonly IConfiguration _configuration;

        public AuthRepository(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
