using DigitalCatalog.Dal.DataContext;
using DigitalCatalog.Domain.Interfaces.Repositories;
using DigitalCatalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = DigitalCatalog.Domain.Models.Document;

namespace DigitalCatalog.Dal.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public DocumentRepository(DatabaseContext context, IConfiguration configuration, IUserRepository userRepository)
        {
            _context = context;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Document>> CreateDocumentRequest(Document document)
        {
            if (document == null) throw new ArgumentNullException("No document was provided.");

            document.isPending = true;
            document.isDeclined = false;
            document.StartDate = DateTime.Now;

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            var allDocs = await GetAllDocumentRequestsByUserId(document.UserId);

            return allDocs;
        }

        public async Task<IEnumerable<Document>> GetAllDocumentRequestsByUserId(int userId)
        {
            return await _context.Documents
                .Where(d => d.UserId == userId)
                .OrderByDescending(d => d.StartDate)
                .Include(d => d.User)
                .Include(d => d.DocumentType)
                .ToListAsync() ??
                throw new KeyNotFoundException("User not found.");
        }

        public async Task<IEnumerable<DocumentType>> GetDocumentTypes()
        {
            return await _context.DocumentTypes.ToListAsync();
        }

        public async Task<Document> GetDocumentById(int documentId)
        {
            return await _context.Documents
                .Include(d => d.User)
                .Include(d => d.DocumentType)
                .FirstOrDefaultAsync(d => d.Id == documentId) ??
                throw new KeyNotFoundException("Document not found.");
        }

        public async Task<IEnumerable<Document>> GetAllDocumentRequestsByStudyYear(int year)
        {
            return await _context.Documents
                .Where(d => d.User.Year == year)
                .OrderByDescending(d => d.StartDate)
                .Include(d => d.User)
                .Include(d => d.DocumentType)
                .ToListAsync() ??
                throw new KeyNotFoundException("User not found.");
        }

        public async Task<IEnumerable<Document>> SetDocumentRequestStatus(int documentId, int secretaryId, bool isDeclined)
        {
            var document = await GetDocumentById(documentId);
            var secretary = await _userRepository.GetUserById(secretaryId);

            if (document == null) throw new ArgumentNullException("No document was provided.");
            if (secretary == null) throw new ArgumentNullException("No secretary found.");

            document.isPending = false;
            document.isDeclined = isDeclined;
            document.EndDate = DateTime.Now;

            await _context.SaveChangesAsync();

            var allDocs = await GetAllDocumentRequestsByStudyYear(secretary.Year);

            return allDocs;
        }
    }
}
