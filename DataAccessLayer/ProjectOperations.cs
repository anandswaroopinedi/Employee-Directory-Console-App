using DataAccessLayer.Interface;
using Models;
using System.Text.Json;

namespace DataAccessLayer
{
    public class ProjectOperations:IProjectOperations
    {
        public static string FilePathLocation = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Project.json";
        public List<ProjectModel> read()
        {
            using (StreamReader reader = new StreamReader(FilePathLocation))
            {
                string jsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonSerializer.Deserialize<List<ProjectModel>>(jsonData);
                }
            }
            return new List<ProjectModel>();
        }
        public void write(List<ProjectModel> projectList)
        {
            string jsonData = JsonSerializer.Serialize(projectList, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathLocation, jsonData);
        }
    }
}
