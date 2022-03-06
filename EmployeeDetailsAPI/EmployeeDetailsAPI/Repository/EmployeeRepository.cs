using EmployeeDetailsAPI.Database;
using EmployeeDetailsAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDetailsAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        MasterData masterData = new MasterData();


        public Employee AddEmployee(Employee employee)
        {
            Employee emp = masterData.GetData().LastOrDefault();
            employee.id = emp.id + 1;
            masterData.AddUpdateData(employee, "Create");
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            masterData.DeleteData(id);
        }

        public void EditEmployee(Employee employee)
        {
            masterData.AddUpdateData(employee, "Update");
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = masterData.GetData().SingleOrDefault(x => x.id == id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = masterData.GetData();
            return employees;
        }

    }
}
