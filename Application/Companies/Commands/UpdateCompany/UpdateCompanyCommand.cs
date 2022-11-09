using MediatR;


namespace Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

    }
}
