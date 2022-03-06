using EmployeeDetailsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Database
{
    public interface IMasterData
    {
        List<Employee> GetData();

        void AddUpdateData(Employee employee, string operation);

        void DeleteData(int employeeId);

    }
}
