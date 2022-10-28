using MediatR;

namespace Application.Companies.Queries.GetCompany.ListByIds
{
    public class GetCompanyListByIdsQuery : IRequest<CompanyListDetailsVM>
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}
