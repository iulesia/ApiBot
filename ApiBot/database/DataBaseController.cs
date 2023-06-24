using Microsoft.AspNetCore.Mvc;
using Model;

using Npgsql;
using apiconst;
using Newtonsoft.Json;

using TgBot.DataBase;
using TelegrBot.dataBase;

namespace TgBot.DataBase
{
    [ApiController]
    [Route("database")]
    public class DatabaseController : ControllerBase
    {

        private readonly ILogger<DatabaseController> _logger;
        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;
        }
        Database films = new Database();

        [HttpPost("movie/add")]
        public async Task<IActionResult> AddWatchedMovieAsync(Films movie)
        {
            await films.AddWatchedMovieAsync(movie);
            return Ok();
        }


        [HttpGet("movie/get")]
        public async Task<IActionResult> GetMoviesByUserId(long id)
        {
            try
            {

                var movies = films.GetMoviesByUserId(id);

                if (movies.Count > 0)
                {
                    return Ok(movies);
                }
                else
                {
                    return NotFound("Список фільмів порожній.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Помилка сервера: " + ex.Message);
            }
        }
        

        [HttpDelete("movie/delete")]
        public async Task<IActionResult> DeleteWatchedMovieAsync(string[] Movie_name)
        {
            await films.DeleteWatchedMovieAsync(Movie_name);
            return Ok();

        }


    }
}
