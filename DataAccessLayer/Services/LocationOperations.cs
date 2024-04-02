using DataAccessLayer.Interface;
using Models;
using System.Text.Json;

namespace DataAccessLayer.Services
{
    public class LocationOperations : ILocationOperations
    {
        public static string FilePathLocation = @"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Repository\Location.json";
        public List<Location> read()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePathLocation))
                {
                    string jsonData = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        return JsonSerializer.Deserialize<List<Location>>(jsonData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Location data: {ex.Message}");
            }
            return new List<Location>();
        }
        public bool write(List<Location> locationsList)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(locationsList, new JsonSerializerOptions
                {
                    WriteIndented = true // Optional: Format the JSON for better readability
                });
                File.WriteAllText(FilePathLocation, jsonData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing Location data: {ex.Message}");
                return false;
            }
        }
    }
}
