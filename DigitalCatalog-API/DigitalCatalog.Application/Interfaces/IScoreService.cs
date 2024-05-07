using DigitalCatalog.Application.Dtos.Score;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Interfaces
{
    public interface IScoreService
    {
        Task<ServiceResponse<IEnumerable<GetAcademicRecordDto>>> GetAcademicRecordByUserId(int userId);
    }
}
