using DigitalCatalog.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Dtos.Forum
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public GetUserProfileDto User { get; set; }
        public string Message { get; set; }
        public DateTime PostedAt { get; set; }
        public string? AttachedFile { get; set; }
    }
}
