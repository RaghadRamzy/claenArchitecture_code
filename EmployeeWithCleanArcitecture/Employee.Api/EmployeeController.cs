using Employee.Application.Interfaces;
using Employee.Domain;
using Employee.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await employeeRepository.GetAllAsync();
            return Ok(employees);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(employee employee)
        {
            await employeeRepository.AddAsync(employee);

            return CreatedAtAction(nameof(Get),new { id = employee.Id },employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            var existingEmployee = await employeeRepository.GetByIdAsync(id);

            if (existingEmployee == null)
                return NotFound();

            await employeeRepository.UpdateAsync(employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            await employeeRepository.DeleteAsync(employee);

            return NoContent();
        }

    }
}
