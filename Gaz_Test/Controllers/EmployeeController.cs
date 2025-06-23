using Domain.Entity;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Gaz_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("by-department")]
        public async Task<ActionResult<ICollection<Employee>>> GetByDepartment(Guid departmentId)
        {
            var result = await _employeeService.GetEmployeesByDepartment(departmentId);
            return Ok(result);
        }

        [HttpGet("by-leader")]
        public async Task<ActionResult<ICollection<Employee>>> GetByLeader(Guid leaderId)
        {
            var subs = await _employeeService.GetEmployeesByLeader(leaderId);

            if (subs.Count == 0)
                return NotFound("У сотрудника в подчинении нет ни одного сотрудника");

            return Ok(subs);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddEmployee(Employee employee)
        {
            var id = await _employeeService.AddEmployee(employee);
            return Ok(id);
        }
    }
}
