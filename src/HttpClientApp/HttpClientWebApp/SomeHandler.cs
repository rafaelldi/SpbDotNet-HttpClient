using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientWebApp
{
    public class SomeHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var sw = new Stopwatch();
            
            sw.Start();
            var response = await base.SendAsync(request, cancellationToken);
            sw.Stop();
            
            Console.WriteLine($"Time elapsed: {sw.Elapsed}");
            return response;
        }
    }
}