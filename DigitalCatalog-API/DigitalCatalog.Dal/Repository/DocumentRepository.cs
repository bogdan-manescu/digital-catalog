using DigitalCatalog.Dal.DataContext;
using DigitalCatalog.Domain.Interfaces.Repositories;
using DigitalCatalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Dal.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public DocumentRepository(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
    }
}
