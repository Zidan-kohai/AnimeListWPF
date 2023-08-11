using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace AnimeList.Scripts
{
    internal class RestClient
    {
        private static HttpClient client = new HttpClient();
        public static string baseUrl = "https://azerlord.bsite.net/api/"; 

        public string Get(string path)
        {
            var response = client.GetAsync(baseUrl + path).GetAwaiter().GetResult();
            return response.Content.ReadAsStringAsync().Result;

        }

        public string Post(string path, object data)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = client.PostAsync(baseUrl + path, stringContent).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
