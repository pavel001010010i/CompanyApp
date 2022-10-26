using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Companies.Queries.GetCompany.Details
{
    public class GetCompanyDetailsQueryHandler
        : IRequestHandler<GetCompanyDetailsQuery, CompanyDTO>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCompanyDetailsQueryHandler(IDbContext dbContext, IMapper mapper) 
            => (_dbContext, _mapper) = (dbContext, mapper);
       
        public async Task<CompanyDTO> Handle(GetCompanyDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Companies.FirstOrDefaultAsync(company =>
            company.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Company), request.Id);

            return _mapper.Map<CompanyDTO>(entity);
        }
    }
}
