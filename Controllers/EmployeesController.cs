using CrudWebApi.EmployeeData;
using CrudWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private IEmployeeData _employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetEmployee()
        {
            //http ok
            return Ok(_employeeData.GetEmployee());
        }
        [HttpGet("GetEmployee")]
        //[Route("api/[controller]/{id}")]

        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if(employee!=null)
            {
                return Ok(_employeeData.GetEmployee(id));

            }
            //404 not found
            return NotFound($"Employee with Id:{id} was not found");
            //http ok
        }

        [HttpPost("AddEmployee")]
        //[Route("api/[controller]/{id}")]

        public IActionResult AddEmployee(Employee _employee)
        {
            _employeeData.AddEmployee(_employee);

            //httpcontext.request.scheme->for autocreate url ,_employee.Id(newly created object)
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + _employee.Id, _employee);
            //http ok
        }

        [HttpPatch("EdiEmployee")]
        //[Route("api/[controller]/{id}")]

        public IActionResult EditEmployee(Guid id,Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);
            if (existingEmployee != null)
            {
                employee.Id = existingEmployee.Id;

                _employeeData.EditEmployee(employee);

            }
            return Ok(employee);
        }


        [HttpDelete("DeleteEmployee")]
        //[Route("api/[controller]/{id}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
               _employeeData.DeleteEmployee(employee);
                return Ok();

            }
            //404 not found
            return NotFound($"Employee with Id:{id} was not found");
            //http ok
        }
    }
}

