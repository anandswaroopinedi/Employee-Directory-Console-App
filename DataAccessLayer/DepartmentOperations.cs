using DataAccessLayer.Interface;
using Models;
using System.Text.Json;

namespace DataAccessLayer
{
    public class DepartmentOperations : IDepartmentOperations
    {
        private static string FilePathDepartment = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Department.json";

        public void write(List<DepartmentModel> deptList)
        {
            string jsonData = JsonSerializer.Serialize(deptList, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathDepartment, jsonData);
        }
        public List<DepartmentModel> read()
        {
            using (StreamReader reader = new StreamReader(FilePathDepartment))
            {
                string jsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonSerializer.Deserialize<List<DepartmentModel>>(jsonData);
                }
            }
            return new List<DepartmentModel>();
        }
    }
}
