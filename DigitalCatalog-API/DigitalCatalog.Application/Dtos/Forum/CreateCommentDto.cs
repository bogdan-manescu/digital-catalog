﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Application.Dtos.Forum
{
    public class CreateCommentDto
    {
        public int UserId { get; set; }
        public string Message { get; set; }
        public string? AttachedFile { get; set; }
    }
}
