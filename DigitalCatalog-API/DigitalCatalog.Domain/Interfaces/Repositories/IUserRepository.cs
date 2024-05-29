using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> AddUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<Faculty>> GetAllFaculties();
        Task<IEnumerable<Group>> GetAllGroups();
        Task<IEnumerable<Role>> GetAllRoles();
    }
}
