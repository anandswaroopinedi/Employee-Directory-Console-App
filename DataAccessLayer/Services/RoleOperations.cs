using DataAccessLayer.Interface;
using Models;
using System.Text.Json;

namespace DataAccessLayer.Services
{
    public class RoleOperations : IRoleOperations
    {
        public static string FilePathRole = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Repository\Role.json";
        public bool write(List<Roles> roleList)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(roleList, new JsonSerializerOptions
                {
                    WriteIndented = true // Optional: Format the JSON for better readability
                });
                File.WriteAllText(FilePathRole, jsonData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing project data: {ex.Message}");
                return false;
            }
        }
        public List<Roles> read()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePathRole))
                {
                    string jsonData = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        return JsonSerializer.Deserialize<List<Roles>>(jsonData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing project data: {ex.Message}");
            }
            return new List<Roles>();
        }
    }
}
