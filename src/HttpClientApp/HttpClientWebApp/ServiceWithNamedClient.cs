using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientWebApp
{
    public class ServiceWithNamedClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceWithNamedClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> GetSomeData()
        {
            var client = _httpClientFactory.CreateClient("some-site");
            var response = await client.GetAsync("/get-some-data");
            return response;
        }
    }
}