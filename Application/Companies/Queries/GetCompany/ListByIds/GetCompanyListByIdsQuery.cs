using MediatR;

namespace Application.Companies.Queries.GetCompany.ListByIds
{
    public class GetCompanyListByIdsQuery : IRequest<CompanyListDetailsVm>
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}
