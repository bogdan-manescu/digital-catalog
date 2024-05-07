
using DigitalCatalog.Application.Dtos.Course;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Dtos.Score
{
    public class GetAcademicRecordDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public GetCourseDto Course { get; set; }
        public int TotalScore { get; set; }
    }
}
