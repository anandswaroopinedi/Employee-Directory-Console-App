using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Presentation.Services;
using System.Text.Json;

namespace EmployeeDirectoryConsoleApp.DataPresentation
{
    public class OverLoadingOperations
    {
        public static string FilePathEmployee = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\Data\Employee.json";
        public static string FilePathDepartment = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\Data\Department.json";
        public static string FilePathLocation = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\Data\Location.json";
        public static string FilePathRole = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\Data\Role.json";
        public static void StoreData(List<EmployeeModel> employees)
        {
            string jsonData = JsonSerializer.Serialize(employees, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathEmployee, jsonData);
        }
        public static void StoreData(List<DepartmentModel> departments)
        {
            string jsonData = JsonSerializer.Serialize(departments, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathDepartment, jsonData);
        }
        public static void StoreData(List<LocationModel> locations)
        {
            string jsonData = JsonSerializer.Serialize(locations, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathLocation, jsonData);
        }
        public static List<EmployeeModel> FetchData()
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
        public static List<DepartmentModel> FetchDepartments()
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
        public static List<LocationModel> FetchLocations()
        {
            using (StreamReader reader = new StreamReader(FilePathLocation))
            {
                string jsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonSerializer.Deserialize<List<LocationModel>>(jsonData);
                }
            }
            return new List<LocationModel>();
        }
        public static void StoreRolesData()
        {
            string jsonData = JsonSerializer.Serialize(RoleManagement.RoleList, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathRole, jsonData);
        }
        public static List<RolesModel> FetchRolesData()
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
        public static void CreateJsonFile()
        {
            if (!File.Exists(FilePathEmployee))
            {
                File.Create(FilePathEmployee).Close();
            }
        }
    }
}
