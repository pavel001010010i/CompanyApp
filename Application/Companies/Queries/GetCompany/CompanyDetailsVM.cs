using Application.Common.Mapping;
using AutoMapper;
using Domain;


namespace Application.Companies.Queries.GetCompany
{
    public class CompanyDetailsVm : IMapWith<Company>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "None";
        public string FullAddress { get; set; } = "None";

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Company, CompanyDetailsVm>()
            .ForMember(c => c.FullAddress,
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }
    }
}
