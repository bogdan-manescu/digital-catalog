using AutoMapper;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DigitalCatalog.Application.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ScoreService(IScoreRepository scoreRepository, IMapper mapper, IConfiguration configuration)
        {
            _scoreRepository = scoreRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<IEnumerable<GetAcademicRecordDto>>> GetAcademicRecordByUserId(int userId)
        {
            var response = new ServiceResponse<IEnumerable<GetAcademicRecordDto>>();
            var academicRecord = await _scoreRepository.GetAcademicRecordByUserId(userId);

            response.Data = _mapper.Map<IEnumerable<GetAcademicRecordDto>>(academicRecord);

            return response;
        }
    }
}
