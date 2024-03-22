﻿using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.StreamOperations
{
    public class ByteStreamOperations
    {
        public static string FilePathEmployee = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\DataPresentation\Data\Employee.json";
        public static string FilePathDepartment = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\DataPresentation\Data\Department.json";
        public static string FilePathLocation = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\DataPresentation\Data\Location.json";
        public static string FilePathRole = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Employee Directory Console App\DataPresentation\Data\Role.json";
        public static void StoreEmployeeData()
        {
            string jsonData = JsonSerializer.Serialize(EmployeeManagement.EmployeeList, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathEmployee, jsonData);
        }
        public static void StoreDepartments()
        {
            string jsonData = JsonSerializer.Serialize(StartApp.DepartmentList, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathDepartment, jsonData);
        }
        public static void StoreLocations()
        {
            string jsonData = JsonSerializer.Serialize(StartApp.LocationList, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathLocation, jsonData);
        }
        public static List<EmployeeModel> FetchEmployeeData()
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
