using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Interfaces
{
    public interface IProfileService
    {
        Task<ServiceResponse<GetUserDto>> UpdateProfile(UpdateProfileDto profile);
        Task<ServiceResponse<GetUserDto>> UpdateLoginCredentials(UpdateLoginCredentialsDto loginCredentials);
    }
}
