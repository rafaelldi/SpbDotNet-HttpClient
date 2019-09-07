using System.Threading.Tasks;
using Refit;

namespace HttpClientWebApp
{
    public interface ISomeSiteApi
    {
        [Get("/get-some-data")]
        Task<SomeData> GetSomeData();
    }
}