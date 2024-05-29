using AutoMapper;
using DigitalCatalog.Application.Dtos.Article;
using DigitalCatalog.Application.Dtos.Faculty;
using DigitalCatalog.Application.Dtos.Group;
using DigitalCatalog.Application.Dtos.Role;
using DigitalCatalog.Application.Dtos.Score;
using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Domain.Interfaces.Repositories;
using DigitalCatalog.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<IEnumerable<GetUserProfileDto>>> AddUser(AddUserDto user)
        {
            var response = new ServiceResponse<IEnumerable<GetUserProfileDto>>();
            var users = await _userRepository.AddUser(_mapper.Map<User>(user));

            response.Data = _mapper.Map<IEnumerable<GetUserProfileDto>>(users);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetUserProfileDto>>> GetAllUsers()
        {
            var response = new ServiceResponse<IEnumerable<GetUserProfileDto>>();
            var users = await _userRepository.GetAllUsers();

            response.Data = _mapper.Map<IEnumerable<GetUserProfileDto>>(users);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetFacultyDto>>> GetAllFaculties()
        {
            var response = new ServiceResponse<IEnumerable<GetFacultyDto>>();
            var faculties = await _userRepository.GetAllFaculties();

            response.Data = _mapper.Map<IEnumerable<GetFacultyDto>>(faculties);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetGroupDto>>> GetAllGroups()
        {
            var response = new ServiceResponse<IEnumerable<GetGroupDto>>();
            var groups = await _userRepository.GetAllGroups();

            response.Data = _mapper.Map<IEnumerable<GetGroupDto>>(groups);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetRoleDto>>> GetAllRoles()
        {
            var response = new ServiceResponse<IEnumerable<GetRoleDto>>();
            var roles = await _userRepository.GetAllRoles();

            response.Data = _mapper.Map<IEnumerable<GetRoleDto>>(roles);

            return response;
        }
    }
}
