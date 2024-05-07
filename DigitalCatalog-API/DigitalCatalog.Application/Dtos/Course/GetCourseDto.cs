using DigitalCatalog.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Dtos.Course
{
    public class GetCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditPoints { get; set; }
        public int TeacherId { get; set; }
        public GetUserProfileDto Teacher { get; set; }
    }
}
