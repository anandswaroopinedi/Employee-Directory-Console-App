using DataLinkLibrary.Interface;
using Models;
using System.Text.Json;

namespace DataLinkLibrary
{
    public class EmployeeOperations : IEmployeeOperations
    {
        public static string FilePathEmployee = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Employee.json";
        public void write(List<EmployeeModel> employeesList)
        {
            string jsonData = JsonSerializer.Serialize(employeesList, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathEmployee, jsonData);
        }
        public List<EmployeeModel> read()
        {
            using (StreamReader reader = new StreamReader(FilePathEmployee))
            {
                string jsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonSerializer.Deserialize<List<EmployeeModel>>(jsonData);
                }
            }
            return new List<EmployeeModel>();
        }
    }
}
