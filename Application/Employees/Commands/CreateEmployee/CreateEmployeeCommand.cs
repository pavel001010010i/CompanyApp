using Domain;
using MediatR;

namespace Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public Guid CompanyId { get; set; }
        public Employee Employee { get; set; }
    }
}
