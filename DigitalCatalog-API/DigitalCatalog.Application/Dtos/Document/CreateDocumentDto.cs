using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Dtos.Document
{
    public class CreateDocumentDto
    {
        public int UserId { get; set; }
        public int DocumentTypeId { get; set; }
        public string Description { get; set; }
    }
}
