using Application.Common.Mapping;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest, IMapWith<Employee>
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeCommand, Employee>();
        }
    }
}
