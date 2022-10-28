using Application.Common.Exceptions;
using Application.Employees.Queries.Get;
using Application.Employees.Queries.Get.Details;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Companies.Queries.GetCompany.Details
{
    public class GetEmployeeDetailsQueryHandler
        : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetEmployeeDetailsQueryHandler(IDbContext dbContext, IMapper mapper) 
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EmployeeDetailsVm> Handle(GetEmployeeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees.FirstOrDefaultAsync(employee =>
            employee.Id == request.Id, cancellationToken);

            if (entity == null || entity.CompanyId != request.CompanyId)
                throw new NotFoundException(nameof(Company), request.Id);

            return _mapper.Map<EmployeeDetailsVm>(entity);
        }
    }
}
