using AutoMapper;
using BusinessEmployeService.Core.Dto;
using BusinessEmployeService.Domain.Entities;

namespace BusinessEmployeService.Core
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDtoBase>();
        }
    }
}
