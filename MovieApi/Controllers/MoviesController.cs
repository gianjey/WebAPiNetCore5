using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiNetCore5.Models;
using WebApiNetCore5.Repositories;

namespace WebApiNetCore5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _movieRepository.Get();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            return await _movieRepository.Get(id);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            await _movieRepository.Update(movie);

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            var newMovie = await _movieRepository.Create(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = newMovie.Id }, newMovie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movieToDelete = await _movieRepository.Get(id);
            if (movieToDelete == null)
                return NotFound();

            await _movieRepository.Delete(movieToDelete.Id);
            return NoContent();
        }
    }
}