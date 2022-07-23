using HRMSFinal.Repository.Models;
using HRMSFinal.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSFinal.Repository.Interfaces
{
   public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> InsertEmployee(Employee emp);
        Task<List<DeptEmp>> GetEmpDetails(int? DeptId);
        Task<Employee> DeleteEmp(int? EmpId);
        Task<Employee> UpdateEmp(Employee emp);
    }
}
