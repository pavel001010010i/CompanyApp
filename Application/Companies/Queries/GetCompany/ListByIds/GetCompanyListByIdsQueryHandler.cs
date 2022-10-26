using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Queries.GetCompany.ListByIds
{
    public class GetCompanyListByIdsQueryHandler
        : IRequestHandler<GetCompanyListByIdsQuery, CompanyListDTO>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCompanyListByIdsQueryHandler(IDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CompanyListDTO> Handle(GetCompanyListByIdsQuery request, CancellationToken cancellationToken)
        {
            var companyQuery = await _dbContext.Companies
                .Where(x => request.Ids.Contains(x.Id))
                .OrderBy(x => x.Name)
                .AsNoTracking()
                .ProjectTo<CompanyDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if(companyQuery.Count != request.Ids.Count())
            {
                throw new NotFoundException(nameof(Company), string.Join(", ", request.Ids));
            }

            return new CompanyListDTO { Companies = companyQuery };
        }
    }
}
