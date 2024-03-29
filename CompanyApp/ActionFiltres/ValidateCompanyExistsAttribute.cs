﻿using Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyApp.ActionFiltres
{
    public class ValidateCompanyExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<ValidateCompanyExistsAttribute> _logger;
        public ValidateCompanyExistsAttribute(IRepositoryManager repository, ILogger<ValidateCompanyExistsAttribute> logger) 
            => (_repository, _logger) = (repository,logger);

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
       ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var id = (Guid)context.ActionArguments["id"];
            var company = await _repository.Company.GetCompanyAsync(id, trackChanges);
            if (company == null)
            {
                _logger.LogInformation($"Company with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("company", company);
                await next();
            }
        }

    }
}
