using MediatR;

namespace Application.Companies.Queries.GetCompany.Details
{
    public class GetCompanyDetailsQuery : IRequest<CompanyDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
