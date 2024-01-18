using System.Text.Json;
using Thread_Task_AwaitAsync.Domain.Entities;
namespace Thread_Task_AwaitAsync.Helper.Helpers
{
    public class UserHelper
    {
        public async Task<List<Users>> GetDataHttp(Predicate<Users> filter)
        {
            HttpClient client = new();
            try
            {
                string url = "https://jsonplaceholder.typicode.com/posts";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    List<Users> userList = JsonSerializer.Deserialize<List<Users>>(responseData);
                    var newUsersList = userList.FindAll(filter);
                    string filePath = @"C:\Users\User\Desktop\Code Academy\Tasks\Task-4_09.10.23\Thread-Task-AwaitAsync\Users.txt";
                    //PS:JsonSerializerOptions boyuk ve kichik herfleri insensitive elemek uchun istifade olunur
                    string jsonResult = JsonSerializer.Serialize(newUsersList, new JsonSerializerOptions { WriteIndented = true });
                    using (StreamWriter streamWriter = new StreamWriter(filePath))
                    {
                        streamWriter.Write(jsonResult);
                    }
                    using (StreamReader streamReader = new StreamReader(filePath))
                    {
                        string fileContent = streamReader.ReadToEnd();
                        Console.WriteLine(fileContent);
                    }
                    return newUsersList;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}