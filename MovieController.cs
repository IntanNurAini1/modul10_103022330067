using Microsoft.AspNetCore.Mvc;
using modul10_103022330067.Controllers;
using System.Collections.Generic;
using modul10_103022330067;
namespace modul10_103022330067.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> MovieList = new List<Movie>
        {
            new Movie("The Shawshank Redemption", "Frank Darabont", new List<string> {"Tim Robbins", "Morgan Freeman", "Bob Gunton"}, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie("The Godfather", "Francis Ford Coppola", new List<string> {"Marlon Brandon", "AI Pacino", "James Caan"}, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son."),
            new Movie("The Dark Knight", "Christopher Nolan", new List<string> {"Christian Bale", "Heath Ledger", "Aaron Eckhart"}, "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.")
        };

        [HttpGet]
        public ActionResult<List<Movie>> GetAllMovies()
        {
            return MovieList;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            if (id < 0 || id >= MovieList.Count)
            {
                return NotFound("Movie tidak ditemukan");
            }
            return MovieList[id];
        }

        [HttpPost]
        public ActionResult<Movie> AddMovie([FromBody] Movie movie)
        {
            MovieList.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = MovieList.Count - 1 }, movie);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= MovieList.Count)
            {
                return NotFound("Movie tidak ditemukan");
            }
            MovieList.RemoveAt(id);
            return NoContent();
        }

    }
}
