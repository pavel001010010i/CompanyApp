﻿using Contracts.Entities;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)=>
            FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

        public Company? GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(companyId), trackChanges)
            .SingleOrDefault();

    }

}
