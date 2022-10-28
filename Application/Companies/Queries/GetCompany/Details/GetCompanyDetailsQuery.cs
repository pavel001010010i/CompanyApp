using MediatR;

namespace Application.Companies.Queries.GetCompany.Details
{
    public class GetCompanyDetailsQuery : IRequest<CompanyDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
