using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Presentation.Services;
using System.Text.Json;

namespace EmployeeDirectoryConsoleApp.DataPresentation
{
    internal class RoleOperations : IRoleOperations
    {
        public static string FilePathRole = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\Data\Role.json";
        public void write()
        {
            string jsonData = JsonSerializer.Serialize(RoleManagement.RoleList, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathRole, jsonData);
        }
        public List<RolesModel> read()
        {
            using (StreamReader reader = new StreamReader(FilePathRole))
            {
                string jsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonSerializer.Deserialize<List<RolesModel>>(jsonData);
                }
            }
            return new List<RolesModel>();
        }
    }
}
