using Newtonsoft.Json;
using Model;
using apiconst;
using Npgsql;
using System.Text;
using TgBot.DataBase;
using TgBot.DataBase;
using Telegram.Bot.Types;

namespace Client4
{
    internal class WatchedMovieClient
    {
        private HttpClient _httpClient;
        private static string _address;
        public WatchedMovieClient()
        {
            _address = Constants.address;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_address);
        }

        public async Task<List<Films>> GetWatchedMovieListAsync(long id)
        {
            
            Console.WriteLine(id);
            var response = await _httpClient.GetAsync($"/database/movie/get/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Films>>(content);
            return result;
        }

        public async Task<string> DeleteWatchedMovieAsync(string[] Movie_name)
        {
            var response = await _httpClient.DeleteAsync($"movie/delete/{Movie_name}");
            response.EnsureSuccessStatusCode();
            return "фільм видалено";
            


        }


        public async Task AddWatchedMovieAsync(Films movie)
        {
            var json = JsonConvert.SerializeObject(movie);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/database/movie/add/", content);
            response.EnsureSuccessStatusCode();

            return;
        }

    }
}