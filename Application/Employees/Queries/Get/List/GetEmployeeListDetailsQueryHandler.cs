using Application.Common.Exceptions;
using Application.Companies.Queries.GetCompany;
using Application.Employees.Queries.Get.Details;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Queries.Get.List
{
    public class GetEmployeeListDetailsQueryHandler : IRequestHandler<GetEmployeeListDetailsQuery, EmployeeListDetailsVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetEmployeeListDetailsQueryHandler(IDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EmployeeListDetailsVm> Handle(GetEmployeeListDetailsQuery request,
            CancellationToken cancellationToken)
        {
            
            var entity = await _dbContext.Employees.
                Where(x=>x.CompanyId == request.CompanyId)
                .OrderBy(x => x.Name)
                .AsNoTracking()
                .ProjectTo<EmployeeDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeeListDetailsVm { Employees = entity };
        }
    }
}
