using Microsoft.AspNetCore.Mvc;
using Test_REST.Domain.Helpers;
using Test_REST.Domain.Models;
using Test_REST.Domain.ValueObjects;

namespace webApiApp_2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return _employeeService.GetAllEmployees();
        }

        [HttpGet]
        public IActionResult Get(string referenceNumber)
        {
            var item = _employeeService.GetEmployee(referenceNumber);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpDelete]
        public void Delete(string referenceNumber)
        {
            _employeeService.DeleteEmployee(referenceNumber);
        }

        [HttpPut]
        public IActionResult Update(string referenceNumber, [FromBody] Employee entity)
        {
            if (entity == null || entity.ReferenceNumber != referenceNumber)
            {
                return BadRequest();
            }

            var item = _employeeService.GetEmployee(referenceNumber);
            if (item == null)
            {
                return NotFound();
            }

            _employeeService.UpdateEmployee(entity);

            return new NoContentResult();
        }


        [HttpPost]
        public IActionResult Add(string lastName, Gender gender)
        {
            if (lastName == null)
            {
                return BadRequest();
            }

            _employeeService.AddEmployee(lastName, gender);

            return new NoContentResult();
        }
    }
}
