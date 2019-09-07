using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientWebApp
{
    public class ServiceWithTypedClient
    {
        private readonly SomeSiteClient _client;

        public ServiceWithTypedClient(SomeSiteClient client)
        {
            _client = client;
        }
        
        public async Task<HttpResponseMessage> GetSomeData()
        {
            return await _client.GetSomeData();
        }
    }
}