using System;
using System.Collections.Generic;

namespace LINQ_Practice.Models
{
    public partial class TblEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public int? Salary { get; set; }
        public int? Department { get; set; }
        public string Gender { get; set; }
        public string FatherName { get; set; }

        public virtual TblDepartment DepartmentNavigation { get; set; }
    }
}
