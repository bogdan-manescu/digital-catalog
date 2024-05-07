﻿using DigitalCatalog.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Dtos.Document
{
    public class GetDocumentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public GetUserProfileDto User { get; set; }
        public int DocumentTypeId { get; set; }
        public GetDocumentTypeDto DocumentType { get; set; }
        public string Description { get; set; }
        public bool isPending { get; set; }
        public bool isDeclined { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

