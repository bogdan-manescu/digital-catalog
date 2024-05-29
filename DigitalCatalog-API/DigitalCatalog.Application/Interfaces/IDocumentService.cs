using DigitalCatalog.Application.Dtos.Document;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Interfaces
{
    public interface IDocumentService
    {
        Task<ServiceResponse<IEnumerable<GetDocumentDto>>> CreateDocumentRequest(CreateDocumentDto document);
        Task<ServiceResponse<IEnumerable<GetDocumentDto>>> GetAllDocumentRequestsByUserId(int userId);
        Task<ServiceResponse<IEnumerable<GetDocumentTypeDto>>> GetDocumentTypes();
        Task<ServiceResponse<IEnumerable<GetDocumentDto>>> SetDocumentRequestStatus(int documentId, int secretaryId, bool isDeclined);
        Task<ServiceResponse<IEnumerable<GetDocumentDto>>> GetAllDocumentRequestsByStudyYear(int year);
    }
}
