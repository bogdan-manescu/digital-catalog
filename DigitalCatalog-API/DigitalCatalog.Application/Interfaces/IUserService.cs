using DigitalCatalog.Application.Dtos;
using DigitalCatalog.Application.Dtos.Faculty;
using DigitalCatalog.Application.Dtos.Group;
using DigitalCatalog.Application.Dtos.Role;
using DigitalCatalog.Application.Dtos.Score;
using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<GetUserProfileDto>>> AddUser(AddUserDto user);
        Task<ServiceResponse<IEnumerable<GetUserProfileDto>>> GetAllUsers();
        Task<ServiceResponse<IEnumerable<GetFacultyDto>>> GetAllFaculties();
        Task<ServiceResponse<IEnumerable<GetGroupDto>>> GetAllGroups();
        Task<ServiceResponse<IEnumerable<GetRoleDto>>> GetAllRoles();
    }
}
