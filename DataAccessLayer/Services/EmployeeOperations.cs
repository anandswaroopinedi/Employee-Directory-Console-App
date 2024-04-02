using DataAccessLayer.Interface;
using Models;
using System.Text.Json;

namespace DataAccessLayer.Services
{
    public class EmployeeOperations : IEmployeeOperations
    {
        public static string FilePathEmployee = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Repository\Employee.json";
        public bool write(List<Employee> employeesList)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(employeesList, new JsonSerializerOptions
                {
                    WriteIndented = true // Optional: Format the JSON for better readability
                });

                File.WriteAllText(FilePathEmployee, jsonData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing employee data: {ex.Message}");
                return false; 
            }
        }
        public List<Employee> read()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePathEmployee))
                {
                    string jsonData = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        return JsonSerializer.Deserialize<List<Employee>>(jsonData);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading employee data: {ex.Message}");
            }
            return new List<Employee>();
        }
    }
}
