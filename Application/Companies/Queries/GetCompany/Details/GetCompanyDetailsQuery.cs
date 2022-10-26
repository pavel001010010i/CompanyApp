using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Companies.Queries.GetCompany.Details
{
    public class GetCompanyDetailsQuery : IRequest<CompanyDTO>
    {
        public Guid Id { get; set; }
    }
}
