using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Domain.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Description { get; set; }
        public bool isPending { get; set; }
        public bool isDeclined { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
