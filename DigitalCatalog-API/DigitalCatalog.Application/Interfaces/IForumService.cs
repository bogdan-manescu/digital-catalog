using DigitalCatalog.Application.Dtos.Forum;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Interfaces
{
    public interface IForumService
    {
        Task<ServiceResponse<IEnumerable<GetCommentDto>>> CreateComment(CreateCommentDto comment);
        Task<ServiceResponse<IEnumerable<GetCommentDto>>> GetForum();
    }
}
