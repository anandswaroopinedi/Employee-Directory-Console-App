using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.DataPresentation
{
    internal class RoleOperations:IRoleOperations
    {
        public static string FilePathRole = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\DataPresentation\Data\Role.json";
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
