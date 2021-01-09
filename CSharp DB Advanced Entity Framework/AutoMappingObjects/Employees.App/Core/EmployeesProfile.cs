using AutoMapper;
using Employees.App.Core.Dtos;
using Employees.Models;

namespace Employees.App.Core
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Employee, ManagerDto>()
                .ForMember(dest => dest.Employees, from => from
                .MapFrom(x => x.Employees))
                .ReverseMap();

            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();

            CreateMap<Employee, ListEmployeeDto>()
                .ForMember(dest => dest.Manager, from => from
                .MapFrom(x => x.Manager))
                .ReverseMap();
        }
    }
}
