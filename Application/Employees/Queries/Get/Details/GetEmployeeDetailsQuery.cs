using MediatR;

namespace Application.Employees.Queries.Get.Details
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
    }
}
