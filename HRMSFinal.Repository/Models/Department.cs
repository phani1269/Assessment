﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSFinal.Repository.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
