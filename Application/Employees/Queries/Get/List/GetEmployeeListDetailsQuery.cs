using MediatR;

namespace Application.Employees.Queries.Get.List
{
    public class GetEmployeeListDetailsQuery : IRequest<EmployeeListDetailsVm>
    {
        public Guid CompanyId { get; set; }
    }

}
