
using Newtonsoft.Json;
using apiconst;
using Model;




namespace Client1
{
    public class MovieClient
    {
        private HttpClient _httpClient;
        private static string _address;
        private static string _apikey;
        public MovieClient()
        {
            _address = Constants.address;
            _apikey = Constants.apikey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_address);
        }

        public async Task<Models> GetMovieNowPlayingAsync()
        {
            var response1 = await _httpClient.GetAsync($"movie/now_playing?api_key=b80e51bae0065bb34be7f2a02c0288d0&language=uk-UA&page=1&region=UA");
            response1.EnsureSuccessStatusCode();
            var content1 = response1.Content.ReadAsStringAsync().Result;
            var result1 = JsonConvert.DeserializeObject<Models>(content1);
            return result1;
        }
    }
}

