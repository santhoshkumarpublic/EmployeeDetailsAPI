using EmployeeDetailsAPI.Model;
using EmployeeDetailsAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    //[Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        //private static List<Employee> employees;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeRepository.GetEmployees());

        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"Employee with id : {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.id, employee);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult EditEmployee(Employee employee)
        {
            _employeeRepository.EditEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.id, employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok();
        }

    }
}
