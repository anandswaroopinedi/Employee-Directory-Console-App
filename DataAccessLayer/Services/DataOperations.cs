using DataAccessLayer.Interface;
using Models;
using System.Text.Json;

namespace DataAccessLayer.Services
{
    public class DataOperations:IDataOperations
    {
        public async Task<List<T>> Read<T>(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string jsonData =await reader.ReadToEndAsync();
                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        return JsonSerializer.Deserialize<List<T>>(jsonData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing project data: {ex.Message}");
            }
            return new List<T>();
        }
        public async Task<bool> Write<T>(List<T> t, string filePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(t, new JsonSerializerOptions
                {
                    WriteIndented = true // Optional: Format the JSON for better readability
                });
                await File.WriteAllTextAsync(filePath, jsonData);
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
