using Microsoft.AspNetCore.Mvc;
using Client2;
using Client1;

using Model;

using Npgsql;
using apiconst;
using Newtonsoft.Json;

namespace WebApplication5.api
{



    [ApiController]
    [Route("movie")]
    public class MoviesController : ControllerBase
    {


        private readonly ILogger<MoviesController> logger;
        public MoviesController(ILogger<MoviesController> logger)
        {
            this.logger = logger;
        }
        [HttpGet("cinema_movie")]
        public Models Movies()
        {


            MovieClient client = new MovieClient();
            return client.GetMovieNowPlayingAsync().Result;


        }
        


        [HttpGet("movie_info")]
        public Models GetMovieInfo(string name)
        {


            MovieInfoClient client2 = new MovieInfoClient();
            return client2.GetMovieInfoAsync(name).Result;



        }



    }
}

