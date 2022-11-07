using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler
        : IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly IDbContext _dbContext;
        public CreateCompanyCommandHandler(IDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address,
                Country = request.Country
            };

            await _dbContext.Companies.AddAsync(company, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return company.Id;
        }
    }
}
