using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientWebApp
{
    public class SomeSiteClient
    {
        private readonly HttpClient _client;

        public SomeSiteClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://some-site.com");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<HttpResponseMessage> GetSomeData()
        {
            var response = await _client.GetAsync("/get-some-data");
            return response;
        }
    }
}