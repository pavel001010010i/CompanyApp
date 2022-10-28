using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler
        : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IDbContext _dbContext;
        public CreateEmployeeCommandHandler(IDbContext dbContext) => _dbContext = dbContext;

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Employee
            {
                Id = Guid.NewGuid(),
                CompanyId = request.CompanyId,
                Name = request.Employee.Name,
                Age = request.Employee.Age,
                Position = request.Employee.Position
            };

            await _dbContext.Employees.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
