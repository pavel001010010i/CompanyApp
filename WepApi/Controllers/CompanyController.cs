using Application.Companies.Commands.CreateCompany;
using Application.Companies.Commands.DeleteCompany;
using Application.Companies.Commands.UpdateCompany;
using Application.Companies.Queries.GetCompany.List;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WepApi.Models;
using Application.Companies.Queries.GetCompany;
using Application.Companies.Queries.GetCompany.Details;
using Entities.DTO;
using Application.ModelBinders;
using Application.Companies.Queries.GetCompany.ListByIds;

namespace WepApi.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IMapper _mapper;
        public CompanyController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CompanyListDTO>> GetCompanies()
        {
            var result = await Mediator.Send(new GetCompanyListQuery());
            return Ok(result);
        }


        [HttpGet("collection/({ids})")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var query = new GetCompanyListByIdsQuery { Ids = ids };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(Guid id)
        {
            var query = new GetCompanyDetailsQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CreateCompanyDTO CreateCompanyDTO)
        {
            var command = _mapper.Map<CreateCompanyCommand>(CreateCompanyDTO);
            var company = await Mediator.Send(command);

            return CreatedAtRoute("CompanyById", new { id = company.Id }, company);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyDTO updateCompanyDTO)
        {
            var command = _mapper.Map<UpdateCompanyCommand>(updateCompanyDTO);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var command = new DeleteCompanyCommand { Id = id };
            
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
