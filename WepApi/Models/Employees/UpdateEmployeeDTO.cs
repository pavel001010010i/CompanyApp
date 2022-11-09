using Application.Common.Mapping;
using Application.Employees.Commands.UpdateEmployee;
using AutoMapper;
using Domain;

namespace WepApi.Models.Employees
{
    public class UpdateEmployeeDTO : IMapWith<UpdateEmployeeCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeDTO, UpdateEmployeeCommand>();
        }
    }
}
