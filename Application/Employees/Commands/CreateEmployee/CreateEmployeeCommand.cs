using Application.Common.Mapping;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Employee>, IMapWith<Employee>
    {
        public Guid CompanyId { get; set; }
        public Employee Employee { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeCommand, Employee>()
             .ForMember(c => c.Id,
            opt => opt.MapFrom(x => x.Employee.Id))
             .ForMember(c => c.CompanyId,
            opt => opt.MapFrom(x => x.CompanyId))
             .ForMember(c => c.Name,
            opt => opt.MapFrom(x => x.Employee.Name))
              .ForMember(c => c.Position,
            opt => opt.MapFrom(x => x.Employee.Position))
               .ForMember(c => c.Age,
            opt => opt.MapFrom(x => x.Employee.Age));
        }
    }
}
