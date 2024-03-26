using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Presentation.Services;
using System.Text.Json;

namespace EmployeeDirectoryConsoleApp.DataPresentation
{
    public class EmployeeOperations : IEmployeeOperations
    {
        public static string FilePathEmployee = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\Data\Employee.json";
        public void write()
        {
            string jsonData = JsonSerializer.Serialize(EmployeeManagement.EmployeeList, new JsonSerializerOptions
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
