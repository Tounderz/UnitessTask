using Microsoft.AspNetCore.Mvc;
using UnitessLibrary.Abstracts;
using UnitessLibrary.Models.Dtos;

namespace UnitessTask.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeesController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpPost("list")]
        public IActionResult GetEmployees(ParametersDto model)
        {
            var employees = _employee.GetEmployees(model);
            if (employees == null || employees.Count <= 0)
            {
                return BadRequest();
            }

            return Ok(new { employees = employees });
        }
    }
}
