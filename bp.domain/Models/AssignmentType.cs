﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp.domain.Models
{
    public class AssignmentType(string name) : BaseEntity
    {
        public string Name { get; set; } = name;
    }
}