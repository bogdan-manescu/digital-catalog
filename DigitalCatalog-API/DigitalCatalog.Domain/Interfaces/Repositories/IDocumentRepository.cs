using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Domain.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> CreateDocumentRequest(Document document);
        Task<IEnumerable<Document>> GetAllDocumentRequestsByUserId(int userId);
        Task<IEnumerable<DocumentType>> GetDocumentTypes();
        Task<IEnumerable<Document>> GetAllDocumentRequestsByStudyYear(int year);
        Task<IEnumerable<Document>> SetDocumentRequestStatus(int documentId, int secretaryId, bool status);
    }
}
