using AutoMapper;
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
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProfileService(IProfileRepository profileRepository, IMapper mapper, IConfiguration configuration)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateProfile(UpdateProfileDto profile)
        {
            var response = new ServiceResponse<GetUserDto>();
            var updatedUser = await _profileRepository.UpdateProfile(_mapper.Map<User>(profile));

            response.Data = _mapper.Map<GetUserDto>(updatedUser);
            response.Message = "Profile saved!";

            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateLoginCredentials(UpdateLoginCredentialsDto loginCredentials)
        {
            var response = new ServiceResponse<GetUserDto>();
            var updatedUser = await _profileRepository.UpdateLoginCredentials(_mapper.Map<User>(loginCredentials));

            response.Data = _mapper.Map<GetUserDto>(updatedUser);
            response.Message = "Profile saved!";

            return response;

        }
    }
}
