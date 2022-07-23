using AutoMapper;
using HRMSFinal.Business.Interfaces;
using HRMSFinal.Models;
using HRMSFinal.Repository;
using HRMSFinal.Repository.Interfaces;
using HRMSFinal.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMSFinal.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeBusiness(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeVM>> GetAllEmployees()
        {
            List<Employee> list = await _employeeRepository.GetAllEmployees();
            return _mapper.Map<List<EmployeeVM>>(list);
        }

        public async Task<EmployeeVM> InsertEmployee(EmployeeVM emp)
        {
            var result = await _employeeRepository.InsertEmployee(_mapper.Map<Employee>(emp));
            return _mapper.Map<EmployeeVM>(result);
        }

        public async Task<List<DeptEmpVM>> GetEmpDetails(int? DeptId)
        {
            var list = await _employeeRepository.GetEmpDetails(DeptId);
            return _mapper.Map<List<DeptEmpVM>>(list);
        }
      

        public async Task<EmployeeVM> DeleteEmp(int? EmpId)
        {
            var list = await _employeeRepository.DeleteEmp(_mapper.Map<int>(EmpId));
            return _mapper.Map<EmployeeVM>(list);
        }

        public async Task<EmployeeVM> UpdateEmp(EmployeeVM emp)
        {
            var list = await _employeeRepository.UpdateEmp(_mapper.Map<Employee>(emp));
            return _mapper.Map<EmployeeVM>(list);
        }
    }
}
