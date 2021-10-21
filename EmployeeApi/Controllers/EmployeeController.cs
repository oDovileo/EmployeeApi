using EmployeeApi.Dtos;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreationEmployeeDto employee)
        {
            //var id = await _employeeService.AddAsync(employee);

            //return Ok(employee.Id);
            return Ok(await _employeeService.AddAsync(employee));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmployeeDto companyUpdateDto)
        {
            await _employeeService.UpdateAsync(companyUpdateDto);
            return NoContent();
        }

    }
}
