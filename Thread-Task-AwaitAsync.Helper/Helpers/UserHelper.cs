using Thread_Task_AwaitAsync.Domain.Entities;

namespace Thread_Task_AwaitAsync.Helper.Helpers
{
    public class UserHelper
    {
        private readonly Users _user;
        private const string textPath = @"C:\Users\User\Desktop\Code Academy\Tasks\Task-4_09.10.23\HttpClient\Datas";
        public UserHelper()
        {
            _user = new Users();
        }
        public void GetDataFromTextFile(Users user)
        {

        }

        public async Task<Users> WriteToTextFile()
        {
            HttpClient client = new();
            
            try
            {
                //HttpClient client = new();
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts");
                HttpResponseMessage response = await client.GetAsync("posts/2");
                var data = await response.Content.ReadAsStringAsync();
                Console.WriteLine(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Dispose();
            }
            //StreamReader sr = new StreamReader(textPath);
        }
    }
}

