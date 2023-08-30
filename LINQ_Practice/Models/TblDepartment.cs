using System;
using System.Collections.Generic;

namespace LINQ_Practice.Models
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployees = new HashSet<TblEmployee>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
    }
}
