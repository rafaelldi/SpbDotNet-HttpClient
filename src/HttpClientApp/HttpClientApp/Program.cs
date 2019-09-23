using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await MultipleTasks();
        }

        private static async Task MultipleRequests()
        {
            for (int i = 0; i < 10; i++)
            {
                using (var client = new HttpClient())
                {
                    await client.GetStringAsync("https://google.com");
                }
            }
        }

        private static async Task MultipleTasks()
        {
            var client = new HttpClient();
            var tasks = new List<Task>();
            for (var i = 0; i < 20; i++)
            {
                tasks.Add(client.GetStringAsync("https://google.com"));
            }
            await Task.WhenAll(tasks);
        }
    }
}