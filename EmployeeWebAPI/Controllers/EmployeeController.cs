using EmployeeWebAPI.Entities;
using EmployeeWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase, IRepository<Employee>
    {
        private readonly DataContext _context;
        private static List<Employee> employees = new();

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> Add(Employee employee)
        {
            if (!IsFioUnique(employee).Result.Value)
            {
                return StatusCode(403, "The database already has this Fio, change Fio please");
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employee>>> Get(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("Employee not found");
            }
            return Ok(employee);
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> Update(Employee request)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null)
            {
                return BadRequest("Employee not found");
            }

            if (!IsFioUnique(request).Result.Value)
            {
                return StatusCode(403, "The database already has this Fio, change Fio please");
            }

            employee.Fio = request.Fio;
            employee.JobTitle = request.JobTitle;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Employee>>> Delete(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("Employee not found");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        private async Task<ActionResult<bool>> IsFioUnique(Employee employee)
        {
            bool isUnique = !(await _context.Employees.AnyAsync(x => x.Fio == employee.Fio));
            return isUnique;
        }
    }
}
