using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientVersion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://microsoft.com") };
            
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/") { Version = new Version(2, 0) })
            using (var response20 = await client.SendAsync(request))
                Console.WriteLine($"Request version is {request.Version}\nHTTP Version is: {response20.Version}\n.NET Core Version: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");

            using (var request = new HttpRequestMessage(HttpMethod.Get, "/"))
            using (var response11 = await client.SendAsync(request))
                Console.WriteLine($"Request version is {request.Version}\nHTTP Version is: {response11.Version}\n.NET Core Version: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");

            Console.ReadKey();
        }
    }
}