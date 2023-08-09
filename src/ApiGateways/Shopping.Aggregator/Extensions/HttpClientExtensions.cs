using System.Text.Json;

namespace Shopping.Aggregator.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Error while calling API: {response.ReasonPhrase}");
            }

            var dataString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
