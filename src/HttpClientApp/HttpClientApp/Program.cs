using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                using (var client = new HttpClient())
                {
                    await client.GetStringAsync("https://google.com");
                }
            }
        }
    }
}