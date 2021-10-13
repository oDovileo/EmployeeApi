using EmployeeApi.Dtos;
using EmployeeApi.Entities;
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
            var point = await _employeeService.GetByIdAsync(id);
            return Ok(point);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeModel employee)
        {
            await _employeeService.AddAsync(employee);

            return NoContent();
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
