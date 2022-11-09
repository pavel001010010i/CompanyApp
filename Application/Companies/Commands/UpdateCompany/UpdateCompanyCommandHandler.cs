using Application.Interfaces;
using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler
        :IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IDbContext _dbContext;
        public UpdateCompanyCommandHandler(IDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity =
                 await _dbContext.Companies.FirstOrDefaultAsync(company =>
                 company.Id == request.Id, cancellationToken);

            if(entity == null) 
                throw new NotFoundException(nameof(Company), request.Id);

            entity.Name = request.Name;
            entity.Address = request.Address;
            entity.Country= request.Country;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
