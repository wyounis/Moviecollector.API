using MovieCollector.StarWarsAPIWrapper.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieCollector.StarWarsAPI.Adapters
{
    public class BasicWebAdapter : IWebAdapter
    {
        protected HttpClient client = new HttpClient();
        protected JsonSerializerOptions InputSerializerOptions = new JsonSerializerOptions();

        public BasicWebAdapter()
        {

        }

        public BasicWebAdapter(string baseUrl)
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TType> GetAsync<TType>(string requestUri)
        {
            HttpResponseMessage response = await client.GetAsync(requestUri);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                return JsonSerializer.Deserialize<TType>(responseContent, InputSerializerOptions);
            }
            throw new KeyNotFoundException();
        }
    }
}
