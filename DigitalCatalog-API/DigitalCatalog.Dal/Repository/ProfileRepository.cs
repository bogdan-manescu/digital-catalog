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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DigitalCatalog.Dal.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public ProfileRepository(DatabaseContext context, IConfiguration configuration ,IUserRepository userRepository)
        {
            _context = context;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<User> UpdateProfile(User user)
        {
            var updatedProfile = await _userRepository.GetUserById(user.Id);

            updatedProfile.ProfilePicture = user.ProfilePicture;
            updatedProfile.FirstName = user.FirstName;
            updatedProfile.LastName = user.LastName;
            updatedProfile.Email = user.Email;
            updatedProfile.PhoneNumber = user.PhoneNumber;
            updatedProfile.Year = user.Year;
            updatedProfile.FacultyId = user.FacultyId;
            updatedProfile.RoleId = user.RoleId;
            updatedProfile.GroupId = user.GroupId;
            updatedProfile.Faculty = await GetFacultyById(user.FacultyId);
            updatedProfile.Role = await GetRoleById(user.RoleId);
            updatedProfile.Group = await GetGroupById(user.GroupId);

            await _context.SaveChangesAsync();

            return updatedProfile;
        }

        public async Task<User> UpdateLoginCredentials(User user)
        {
            var updatedProfile = await _userRepository.GetUserById(user.Id);

            updatedProfile.Username = user.Username;
            updatedProfile.Password = user.Password;

            await _context.SaveChangesAsync();

            return updatedProfile;
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id) ??
                throw new KeyNotFoundException("Role not found.");
        }

        public async Task<Faculty> GetFacultyById(int id)
        {
            return await _context.Faculties.FirstOrDefaultAsync(f => f.Id == id) ??
                throw new KeyNotFoundException("Faculty not found.");
        }

        public async Task<Group> GetGroupById(int id)
        {
            return await _context.Groups.FirstOrDefaultAsync(g => g.Id == id) ??
                throw new KeyNotFoundException("Group not found.");
        }
    }
}
