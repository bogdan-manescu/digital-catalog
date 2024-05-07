using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditPoints { get; set; }
        public int TeacherId { get; set; }
        public User Teacher { get; set; }
    }
}
