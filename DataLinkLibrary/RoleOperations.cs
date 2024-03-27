using DataLinkLibrary.Interface;
using Models;
using System.Text.Json;

namespace DataLinkLibrary
{
    public class RoleOperations : IRoleOperations
    {
        public static string FilePathRole = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Role.json";
        public void write(List<RolesModel> roleList)
        {
            string jsonData = JsonSerializer.Serialize(roleList, new JsonSerializerOptions
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
