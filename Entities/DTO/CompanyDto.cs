﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "None";
        public string FullAddress { get; set; } = "None";
    }
}
