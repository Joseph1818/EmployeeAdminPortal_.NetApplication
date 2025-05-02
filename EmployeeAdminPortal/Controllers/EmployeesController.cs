using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    //localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //Constructor injection
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //New Action methods

        //1. Get All employees
        [HttpGet]
        public IActionResult getAllEmployee() {

            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }

        //2.Methods to retrieve a single employee
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getEmployeeByID (Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is null )
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        //3. Add one employee
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            //Coverting AddEmployeeDto to Employee Entity
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                PhoneNumber = addEmployeeDto.PhoneNumber,
                Salary = addEmployeeDto.Salary
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }
        
    }
}
