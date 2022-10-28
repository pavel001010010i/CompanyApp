using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.Get.Details;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WepApi.Models.Employees;

namespace WepApi.Controllers
{
    [Route("api/company/{companyId}/[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IMapper _mapper;
        public EmployeeController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{id}", Name = "GetEmployeeForCompany")]
        public async Task<ActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var query = new GetEmployeeDetailsQuery { Id = id, CompanyId = companyId };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Guid companyId, [FromBody] CreateEmployeeDTO createEmployeeDTO)
        {
            var command = new CreateEmployeeCommand 
            { 
                CompanyId = companyId, 
                Employee = _mapper.Map<Employee>(createEmployeeDTO) 
            };
            var employee = await Mediator.Send(command);
            return CreatedAtRoute("GetEmployeeForCompany", new { companyId = employee.CompanyId, id = employee.Id }, employee);
        }

    }
}
