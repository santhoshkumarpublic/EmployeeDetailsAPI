using EmployeeDetailsAPI.Model;
using System.Collections.Generic;

namespace EmployeeDetailsAPI.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(int id);

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(int id);

        void EditEmployee(Employee employee);

    }
}
