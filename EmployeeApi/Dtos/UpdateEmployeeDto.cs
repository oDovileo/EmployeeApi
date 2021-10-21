using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Dtos
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }       
        public int? CompanyId { get; set; }
        public string GenderType { get; internal set; }
    }
}
