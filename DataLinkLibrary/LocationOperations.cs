using DataLinkLibrary.Interface;
using Models;
using System.Text.Json;

namespace DataLinkLibrary
{
    public class LocationOperations : ILocationOperations
    {
        public static string FilePathLocation = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Location.json";
        public List<LocationModel> read()
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
        public void write(List<LocationModel> locationsList)
        {
            string jsonData = JsonSerializer.Serialize(locationsList, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: Format the JSON for better readability
            });
            File.WriteAllText(FilePathLocation, jsonData);
        }
    }
}
