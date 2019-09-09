using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public async Task<SomeData> GetSomeDataFromString()
        {
            var client = _httpClientFactory.CreateClient("some-site");
            var response = await client.GetAsync("/get-some-data");
            var responseString = await response.Content.ReadAsStringAsync();
            var someData = JsonConvert.DeserializeObject<SomeData>(responseString);
            return someData;
        }
        
        public async Task<SomeData> GetSomeDataFromStream()
        {
            var client = _httpClientFactory.CreateClient("some-site");
            var response = await client.GetAsync("/get-some-data");
            var serializer = new JsonSerializer();
            var stream = await response.Content.ReadAsStreamAsync();
            using (var sr = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(sr))
            {
                var someData = serializer.Deserialize<SomeData>(jsonReader);
                return someData;
            }
        }
    }
}