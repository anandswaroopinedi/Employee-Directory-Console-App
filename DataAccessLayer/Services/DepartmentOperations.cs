using DataAccessLayer.Interface;
using Models;
using System.Text.Json;

namespace DataAccessLayer.Services
{
    public class DepartmentOperations : IDepartmentOperations
    {
        private static string FilePathDepartment = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Json Files\Department.json";

        public bool write(List<Department> deptList)
        {
            if (!File.Exists(FilePathDepartment))
            {
                return false; // Return empty list if file doesn't exist
            }
            try
            {
                string jsonData = JsonSerializer.Serialize(deptList, new JsonSerializerOptions
                {
                    WriteIndented = true // Optional: Format the JSON for better readability
                });
                File.WriteAllText(FilePathDepartment, jsonData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing department data: {ex.Message}");
                return false; 
            }
        }
        /*public async Task<List<DepartmentModel>> read()
        {
            if (!File.Exists(FilePathDepartment))
            {
                return new List<DepartmentModel>(); // Return empty list if file doesn't exist
            }

            try
            {
                string jsonData = await File.ReadAllTextAsync(FilePathDepartment);
                return JsonSerializer.Deserialize<List<DepartmentModel>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading employee data: {ex.Message}");
                return new List<DepartmentModel>(); // Return empty list on error
            }
        }*/
        public List<Department> read()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePathDepartment))
                {
                    string jsonData = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        return JsonSerializer.Deserialize<List<Department>>(jsonData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Department data: {ex.Message}"); 
            }
            return new List<Department>();
        }
    }
}
