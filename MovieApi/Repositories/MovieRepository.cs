using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiNetCore5.Models;

namespace WebApiNetCore5.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _context;

        public MovieRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> Create(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task Delete(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> Get(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task Update(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}