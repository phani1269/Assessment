using HRMSFinal.Repository.Interfaces;
using HRMSFinal.Repository.Models;
using HRMSFinal.Repository.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSFinal.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Mycontext _myContext;
        public EmployeeRepository(Mycontext myContext)
        {
            _myContext = myContext;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _myContext.Employees.ToListAsync();
        }

        public async Task<Employee> InsertEmployee(Employee emp)
        {
            var result = await _myContext.Employees.AddAsync(emp);
            await _myContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<DeptEmp>> GetEmpDetails(int? DeptId)
        {
            var result = await _myContext.DeptEmps.FromSqlRaw("exec GetEmployeesByDept {0}", DeptId).ToListAsync();
            return result;
        }
        public async Task<Employee> DeleteEmp(int? EmpId)
        {
            var result = await _myContext.Employees.FindAsync(EmpId);
           var result1= _myContext.Employees.Remove(result);

            await _myContext.SaveChangesAsync();

            return result1.Entity;
        }
        public async Task<Employee> UpdateEmp(Employee emp)
        {

            var result = await _myContext.Employees.Where(x => x.EmpId == emp.EmpId).SingleOrDefaultAsync();
            _myContext.Employees.Remove(result);
            _myContext.Employees.Update(emp);
           await _myContext.SaveChangesAsync();
            return null;
        }


    }
}
