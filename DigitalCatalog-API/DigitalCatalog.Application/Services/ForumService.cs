using AutoMapper;
using DigitalCatalog.Application.Dtos.Article;
using DigitalCatalog.Application.Dtos.Forum;
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
    public class ForumService : IForumService
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ForumService(IForumRepository forumRepository, IMapper mapper, IConfiguration configuration)
        {
            _forumRepository = forumRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<IEnumerable<GetCommentDto>>> CreateComment(CreateCommentDto comment)
        {
            var response = new ServiceResponse<IEnumerable<GetCommentDto>>();
            var comments = await _forumRepository.CreateComment(_mapper.Map<Comment>(comment));

            response.Data = _mapper.Map<IEnumerable<GetCommentDto>>(comments);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetCommentDto>>> GetForum()
        {
            var response = new ServiceResponse<IEnumerable<GetCommentDto>>();
            var comments = await _forumRepository.GetForum();

            response.Data = _mapper.Map<IEnumerable<GetCommentDto>>(comments);

            return response;
        }
    }
}
