using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  internal static class HttpClientExtensions
  {

    public static Task<HttpResponseMessage> PostAsJsonAsync<T>(ApiClient client, string url, T data)
    {
      var dataAsString = JsonConvert.SerializeObject(data);
      var content = new StringContent(dataAsString);
      content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

      return client.HttpClient.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PutAsJsonAsync<T>(ApiClient client, string url, T data)
    {
      var dataAsString = JsonConvert.SerializeObject(data);
      var content = new StringContent(dataAsString);
      content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

      return client.HttpClient.PutAsync(url, content);
    }

    public static Task<HttpResponseMessage> DeleteAsJsonAsync(ApiClient client, string requestUri)
      => client.HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri));
  }
}