using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientWebApp30
{
    public class SomeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SomeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SomeData> GetSomeData()
        {
            var client = _httpClientFactory.CreateClient("some-site");
            var response = await client.GetAsync("/get-some-data");
            var stream = await response.Content.ReadAsStreamAsync();
            var someDate = await JsonSerializer.DeserializeAsync<SomeData>(stream);
            return someDate;
        }
    }
}