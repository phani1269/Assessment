using HRMSFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSFinal.Business.Interfaces
{
    public interface IEmployeeBusiness
    {
        Task<List<EmployeeVM>> GetAllEmployees();
        Task<EmployeeVM> InsertEmployee(EmployeeVM emp);
        Task<List<DeptEmpVM>> GetEmpDetails(int? DeptId);
        Task<EmployeeVM> DeleteEmp(int? EmpId);
        Task<EmployeeVM> UpdateEmp(EmployeeVM emp);
    }
}
