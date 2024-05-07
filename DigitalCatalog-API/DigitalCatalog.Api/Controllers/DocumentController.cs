using DigitalCatalog.Application.Dtos.Document;
using DigitalCatalog.Application.Interfaces;
using DigitalCatalog.Application.Services;
using DigitalCatalog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCatalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPut("create-document-request")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetDocumentDto>>>> CreateDocumentRequest(CreateDocumentDto document)
        {
            var response = await _documentService.CreateDocumentRequest(document);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-all-document-requests-by-user-id/{userId}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetDocumentDto>>>> GetAllDocumentRequestsByUserId(int userId)
        {
            var response = await _documentService.GetAllDocumentRequestsByUserId(userId);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-document-types")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetDocumentTypeDto>>>> GetDocumentTypes()
        {
            var response = await _documentService.GetDocumentTypes();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
