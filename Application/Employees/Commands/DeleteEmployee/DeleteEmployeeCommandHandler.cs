using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;


namespace Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler
        : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IDbContext _dbContext;
        public DeleteEmployeeCommandHandler(IDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.CompanyId != request.CompanyId)
                throw new NotFoundException(nameof(Employee), request.Id);

            _dbContext.Employees.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
