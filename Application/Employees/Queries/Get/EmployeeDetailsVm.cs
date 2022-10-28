using Application.Common.Mapping;
using AutoMapper;
using Domain;


namespace Application.Employees.Queries.Get
{
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>();
        }
    }
}
