using Application.Companies.Queries.GetCompany;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.Get.Details;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WepApi.Models.Employees;
using Application.Employees.Queries.Get.List;
using Application.Employees.Commands.UpdateEmployee;

namespace WepApi.Controllers
{
    [Route("api/company/{companyId}/[controller]/[action]")]
    public class EmployeeController : BaseController
    {

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<ActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var result = await Mediator.Send(new GetEmployeeDetailsQuery { Id = id, CompanyId = companyId });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<CompanyListDetailsVm>> GetEmployes(Guid companyId)
        {
            var result = await Mediator.Send(new GetEmployeeListDetailsQuery { CompanyId = companyId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Guid companyId, [FromBody] CreateEmployeeDTO createEmployeeDTO)
        {
            //можно так замаппить команду
            var command = new CreateEmployeeCommand 
            { 
                CompanyId = companyId, 
                Employee = Mapper.Map<Employee>(createEmployeeDTO) 
            };
            var employee = await Mediator.Send(command);
            return CreatedAtRoute("GetEmployee", new { companyId = employee.CompanyId, id = employee.Id }, employee);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Guid companyId, [FromBody] UpdateEmployeeDTO updateEmployeeDTO)
        {
            //и можно так замаппить команду, сделал для примера)
            var command = Mapper.Map<UpdateEmployeeCommand>(updateEmployeeDTO);
            command.CompanyId = companyId;
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
