using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.DataPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeDirectoryConsoleApp.Services;

namespace EmployeeDirectoryConsoleApp.DataPresentation
{
    public class DepartmentOperations : IDepartmentOperations
    {
        private static string FilePathDepartment = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\DataPresentation\Data\Department.json";

        public void write()
        {
            string jsonData = JsonSerializer.Serialize(StartApp.DepartmentList, new JsonSerializerOptions
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
