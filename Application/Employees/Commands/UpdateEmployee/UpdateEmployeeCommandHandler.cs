using Application.Common.Exceptions;
using Application.Companies.Commands.UpdateCompany;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Commands.UpdateEmployee
{    
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateEmployeeCommandHandler(IDbContext dbContext, IMapper mapper) 
            => (_dbContext,_mapper) = (dbContext, mapper);

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entityEmployee =
                 await _dbContext.Employees.FirstOrDefaultAsync(employee =>
                 employee.Id == request.Id, cancellationToken);

            if (entityEmployee == null || entityEmployee.CompanyId != request.CompanyId)
                throw new NotFoundException(nameof(Employee), request.Id);

            _mapper.Map(request,entityEmployee);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
