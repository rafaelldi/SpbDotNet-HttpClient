using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientWebApp
{
    public class HeadersHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("some"))
            {
                return new HttpResponseMessage();
            }
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}