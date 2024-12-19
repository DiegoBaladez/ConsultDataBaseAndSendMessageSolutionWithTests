using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue _contentType = new MediaTypeHeaderValue("application/json");

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong calling the API");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false); //ver o que é esse configure Await

            return JsonSerializer.Deserialize<T>(dataAsString);//, new JsonSerializerOptions(PropertyNameCaseInsensitive = true)); olhar esse cara aqui melhor

        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);

            var content = new StringContent(dataAsString); //Pra que usar esse StringContent
            content.Headers.ContentType = _contentType;
            return httpClient.PostAsync(url, content);

        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);

            var content = new StringContent(dataAsString); //Pra que usar esse StringContent
            content.Headers.ContentType = _contentType;
            return httpClient.PutAsync(url, content);

        }
    }
}
