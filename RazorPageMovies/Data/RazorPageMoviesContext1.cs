using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Models;

namespace RazorPageMovies.Data
{
    public class RazorPageMoviesContext1 : DbContext
    {
        public RazorPageMoviesContext1 (DbContextOptions<RazorPageMoviesContext1> options)
            : base(options)
        {
        }

        public DbSet<RazorPageMovies.Models.Movie> Movie { get; set; } = default!;
    }
}
