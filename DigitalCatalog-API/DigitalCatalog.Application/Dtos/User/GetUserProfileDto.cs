﻿using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Dtos.User
{
    public class GetUserProfileDto
    {
        public int Id { get; set; }
        public string? ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Year { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
