using DataAccessLayer.Interface;
using Models;
using System.Text.Json;

namespace DataAccessLayer.Services
{
    public class ProjectOperations : IProjectOperations
    {
        public static string FilePathProject = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Repository\Project.json";
        public List<Project> read()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePathProject))
                {
                    string jsonData = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        return JsonSerializer.Deserialize<List<Project>>(jsonData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading project data: {ex.Message}");
            }
            return new List<Project>();
        }
        public bool write(List<Project> projectList)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(projectList, new JsonSerializerOptions
                {
                    WriteIndented = true // Optional: Format the JSON for better readability
                });
                File.WriteAllText(FilePathProject, jsonData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing project data: {ex.Message}");
                return false;
            }
        }
    }
}
