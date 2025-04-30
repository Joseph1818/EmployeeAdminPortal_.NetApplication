using EmployeeAdminPortal.Data;
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
            this.dbContext=dbContext;
        }

        [HttpGet]
        public IActionResult getAllEmployee(){
            
            var allEmployees = dbContext.Employees.ToList();

            return Ok(allEmployees);
        }
    }
}
