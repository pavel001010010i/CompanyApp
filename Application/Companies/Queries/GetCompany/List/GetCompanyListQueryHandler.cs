﻿using Application.Companies.Queries.GetCompany.Details;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Queries.GetCompany.List
{
    public class GetCompanyListQueryHandler
        : IRequestHandler<GetCompanyListQuery, CompanyListDetailsVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCompanyListQueryHandler(IDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CompanyListDetailsVm> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
        {
            var companyQuery = await _dbContext.Companies
                .OrderBy(x => x.Name)
                .AsNoTracking()
                .ProjectTo<CompanyDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
                
            return new CompanyListDetailsVm { Companies = companyQuery };
        }
    }
}