using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler
        : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateEmployeeCommandHandler(IDbContext dbContext, IMapper mapper)
             => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Employee>(request);

            await _dbContext.Employees.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
