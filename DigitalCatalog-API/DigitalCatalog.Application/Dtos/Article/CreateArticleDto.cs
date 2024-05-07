using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Dtos.Article
{
    public class CreateArticleDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
        public int AuthorId { get; set; }
        public DateTime Created { get; set; }
    }
}
