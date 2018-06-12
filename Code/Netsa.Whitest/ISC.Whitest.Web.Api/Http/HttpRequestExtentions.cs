using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ISC.Whitest.Web.Api.Http
{
    public static class HttpRequestExtentions
    {
        private static readonly HttpClient Client;
        static HttpRequestExtentions()
        {
            Client = new HttpClient();    
        }
    
        public static async Task<TResponse> DispatchAsync<TResponse>(this IHttpRequestBuilder httpRequestBuilder)
        {
            var httpRequest = httpRequestBuilder.Build();
            var response = await Client.SendAsync(httpRequest);
            var responseContent = await response.Content.ReadAsStringAsync();
            //TODO: consider a strategy for non-success responses
            //if (!task.Result.IsSuccessStatusCode) throw new Exception(result);
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }

        public static Task<HttpResponseMessage> DispatchAsync(this IHttpRequestBuilder httpRequestBuilder)
        {
            var httpRequest = httpRequestBuilder.Build();
            return Client.SendAsync(httpRequest);
        }

    }
}
