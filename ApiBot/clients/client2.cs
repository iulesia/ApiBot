using Newtonsoft.Json;
using Model;
using WebApplication5.api;
using apiconst;

namespace Client2
{
    public class MovieInfoClient
    {
        private HttpClient _httpClient;
        private static string _address;
        private static string _apikey;
        public MovieInfoClient()
        {
            _address = Constants.address;
            _apikey = Constants.apikey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_address);
        }

        public async Task<Models> GetMovieInfoAsync(string name)
        {
            var response = await _httpClient.GetAsync($"search/movie?api_key=b80e51bae0065bb34be7f2a02c0288d0&language=uk-UA&query={name}&page=1&include_adult=false");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Models>(content);
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return result;
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.

        }
    }
}