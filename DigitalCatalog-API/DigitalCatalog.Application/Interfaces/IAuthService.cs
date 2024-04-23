using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResponse<GetUserDto>> Login(string username, string password);
    }
}
