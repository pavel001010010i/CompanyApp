using MediatR;

namespace Application.Companies.Queries.GetCompany.ListByIds
{
    public class GetCompanyListByIdsQuery : IRequest<CompanyListDTO>
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}
