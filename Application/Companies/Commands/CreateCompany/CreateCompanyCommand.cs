using Domain;
using MediatR;

namespace Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Company>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}
