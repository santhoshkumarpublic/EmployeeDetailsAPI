using EmployeeDetailsAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Database
{
    public class MasterData : IMasterData
    {
        public List<Employee> GetData()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"Database\MOCK_DATA.json");
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            return employees;
        }

        public void AddUpdateData(Employee employee, string operation)
        {
            string json = File.ReadAllText(@"Database\MOCK_DATA.json");
            List<Employee> employees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(json);
            if (operation == "Update")
            {
                Employee editEmp = employees.SingleOrDefault(x => x.id == employee.id);
                editEmp.first_name = employee.first_name;
                editEmp.last_name = employee.last_name;
                editEmp.email = employee.email;
                editEmp.gender = employee.gender;
                editEmp.status = employee.status;
            }
            else
            {
                employees.Add(employee);
            }
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"Database\MOCK_DATA.json", output);
        }

        public void DeleteData(int employeeId)
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"Database\MOCK_DATA.json");
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            Employee editEmp = employees.SingleOrDefault(x => x.id == employeeId);
            if (editEmp != null)
                employees.Remove(editEmp);
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"Database\MOCK_DATA.json", output);
        }
    }
}
