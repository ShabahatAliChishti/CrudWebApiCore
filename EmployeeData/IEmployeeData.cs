using CrudWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWebApi.EmployeeData
{
    public interface IEmployeeData
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// 
        //return employee list
        List<Employee> GetEmployee();

        //return single employee
        Employee GetEmployee(Guid id);

        //Create Employee
        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        //return employee back and edit employee
        Employee EditEmployee(Employee employee);
    }
}
