using Application.Common.Mapping;
using Application.Companies.Commands.CreateCompany;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
