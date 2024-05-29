﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Dtos.User
{
    public class AddUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Year { get; set; }
        public int RoleId { get; set; }
        public int FacultyId { get; set; }
        public int? GroupId { get; set; }
    }
}
