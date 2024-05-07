using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Domain.Interfaces.Repositories
{
    public interface IScoreRepository
    {
        Task<IEnumerable<Score>> GetAcademicRecordByUserId(int userId);
    }
}
