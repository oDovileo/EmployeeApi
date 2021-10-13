﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Entities
{
    public class CompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<EmployeeModel> Employees { get; set; }
    }
}
