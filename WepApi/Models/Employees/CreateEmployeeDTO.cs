using Application.Common.Mapping;
using AutoMapper;
using Domain;

namespace WepApi.Models.Employees
{
    public class CreateEmployeeDTO : IMapWith<Employee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDTO, Employee>();
        }
    }
}
