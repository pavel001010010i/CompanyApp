using AutoMapper;
using Contracts.Managers;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;


        public EmployeesController(ILogger<EmployeesController> logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _logger.LogInformation($"Company with id: {companyId} doesn't exist in the database.");
            return NotFound();
            }
            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges: false);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return Ok(employeesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _logger.LogInformation($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            var employeeDb = _repository.Employee.GetEmployee(companyId, id, trackChanges: false);
            if (employeeDb == null)
            {
                _logger.LogInformation($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return Ok(employee);
        }
    }

}
