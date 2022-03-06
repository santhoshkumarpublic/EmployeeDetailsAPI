using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Model
{
    public class Employee
    {
        [JsonPropertyName("Id")]
        public int? id { get; set; }

        [JsonPropertyName("FirstName")]
        public string first_name { get; set; }

        [JsonPropertyName("LastName")]
        public string last_name { get; set; }

        [JsonPropertyName("EmailAddress")]
        public string email { get; set; }

        [JsonPropertyName("Gender")]
        public string gender { get; set; }

        [JsonPropertyName("Status")]
        public bool status { get; set; }
    }
}
