﻿using Application.Common.Mapping;
using Application.Companies.Commands.UpdateCompany;
using AutoMapper;

namespace WepApi.Models.Company
{
    public class UpdateCompanyDTO : IMapWith<UpdateCompanyCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCompanyDTO, UpdateCompanyCommand>();
        }
    }
}
