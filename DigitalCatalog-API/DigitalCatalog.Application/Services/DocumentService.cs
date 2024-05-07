using AutoMapper;
using DigitalCatalog.Application.Dtos.Document;
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
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public DocumentService(IDocumentRepository documentRepository, IMapper mapper, IConfiguration configuration)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<IEnumerable<GetDocumentDto>>> CreateDocumentRequest(CreateDocumentDto document)
        {
            var response = new ServiceResponse<IEnumerable<GetDocumentDto>>();
            var docs = await _documentRepository.CreateDocumentRequest(_mapper.Map<Document>(document));

            response.Data = _mapper.Map<IEnumerable<GetDocumentDto>>(docs);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetDocumentDto>>> GetAllDocumentRequestsByUserId(int userId)
        {
            var response = new ServiceResponse<IEnumerable<GetDocumentDto>>();
            var docs = await _documentRepository.GetAllDocumentRequestsByUserId(userId);

            response.Data = _mapper.Map<IEnumerable<GetDocumentDto>>(docs);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetDocumentTypeDto>>> GetDocumentTypes()
        {
            var response = new ServiceResponse<IEnumerable<GetDocumentTypeDto>>();
            var docTypes = await _documentRepository.GetDocumentTypes();

            response.Data = _mapper.Map<IEnumerable<GetDocumentTypeDto>>(docTypes);

            return response;
        }
    }
}
