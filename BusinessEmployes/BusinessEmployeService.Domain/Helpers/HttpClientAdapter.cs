using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusinessEmployeService.Domain.Helpers
{
    public class HttpClientAdapter:IHttpClient
    {
        private readonly HttpClient _client;

        public HttpClientAdapter(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetData<T>(string path)
        {
            var response = await _client.GetAsync(path);
            return await ProcessResponseAsync<T>(response).ConfigureAwait(false);
        }

        private async Task<T> ProcessResponseAsync<T>(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al tratar de realizar la petición " +
                    $"{response.RequestMessage.Method} StatusCode: {response.StatusCode.GetHashCode()}, {result}");
            }

            result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
