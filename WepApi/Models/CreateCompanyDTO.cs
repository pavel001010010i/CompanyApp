using Application.Common.Mapping;
using Application.Companies.Commands.CreateCompany;
using AutoMapper;

namespace WepApi.Models
{
    public class CreateCompanyDTO : IMapWith<CreateCompanyCommand>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCompanyDTO, CreateCompanyCommand>();
        }
    }
}
