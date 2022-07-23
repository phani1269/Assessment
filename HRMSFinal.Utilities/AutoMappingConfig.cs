using AutoMapper;
using HRMSFinal.Models;
using HRMSFinal.Repository.Models;
using HRMSFinal.Repository.ViewModels;
using System;

namespace HRMSFinal.Utilities
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<DeptEmp, DeptEmpVM>().ReverseMap();
        }
    }
}
