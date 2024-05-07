using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Domain.Interfaces.Repositories;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;   
            
        public AuthService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper ;
            _configuration = configuration;
        }
        
        public async Task<ServiceResponse<GetUserDto>> Login(string username, string password)
        {
            var response = new ServiceResponse<GetUserDto>();
            var user = await _userRepository.GetUserByUsername(username);

            if(user.Password != password)
            {
                throw new KeyNotFoundException("Incorrect username or password.");
            }
            else
            {
                response.Data = _mapper.Map<GetUserDto>(user);
                response.Message = "Authentification succeeded!";
            }

            return response;
        }
    }
}
