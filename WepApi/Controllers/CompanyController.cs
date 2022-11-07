using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Application.ModelBinders;
using Application.Companies.Queries.GetCompany;
using Application.Companies.Commands.DeleteCompany;
using Application.Companies.Commands.UpdateCompany;
using Application.Companies.Queries.GetCompany.List;
using Application.Companies.Queries.GetCompany.Details;
using Application.Companies.Queries.GetCompany.ListByIds;
using Application.Companies.Commands.CreateCompany;
using Domain;
using WepApi.Models.Company;

namespace WepApi.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IMapper _mapper;
        public CompanyController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<ActionResult<CompanyDetailsVm>> GetCompany(Guid id)
        {
            var query = new GetCompanyDetailsQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<CompanyListDetailsVm>> GetCompanies()
        {
            var result = await Mediator.Send(new GetCompanyListQuery());
            return Ok(result);
        }


        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var query = new GetCompanyListByIdsQuery { Ids = ids };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CreateCompanyDTO CreateCompanyDTO)
        {
            var command = _mapper.Map<CreateCompanyCommand>(CreateCompanyDTO);
            var companyId = await Mediator.Send(command);
            return Ok(companyId);
        }

        [HttpPost("collection")]
        public async Task<ActionResult> CreateCompanyCollection([FromBody] IEnumerable<CreateCompanyDTO> CreateCompanyCollectionDTO)
        {

            foreach(var company in CreateCompanyCollectionDTO)
            {
                var command = _mapper.Map<CreateCompanyCommand>(company);
            }
            return Ok();
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
