using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler
        : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IDbContext _dbContext;
        public DeleteCompanyCommandHandler(IDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Companies
                .FindAsync(new object[] {request.Id}, cancellationToken);

            if(entity == null)
                throw new NotFoundException(nameof(Company), request.Id);

            _dbContext.Companies.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
