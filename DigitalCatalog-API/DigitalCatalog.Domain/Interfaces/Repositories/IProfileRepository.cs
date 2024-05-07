using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Domain.Interfaces.Repositories
{
    public interface IProfileRepository
    {
        Task<User> UpdateProfile(User user);
        Task<User> UpdateLoginCredentials(User user);
    }
}
