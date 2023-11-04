using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Data;

namespace RazorPageMovies.Models

{
    public static class SeedData
    {
        public static void Initalizate(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMoviesContext1(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPageMoviesContext1>>()))
            {
                //En caso de contexto nulo, se manda msj de error
                if(context==null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPageMoviesContext1");
                }
                if (context.Movie.Any())
                {
                    //BD muestra todo lo que tiene esta clase
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "WHEN HARRY MET SALLY",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "ROMANTIC COMEDY",
                        Price = 7.9M,
                        Rating = "R"
                    },
                    new Movie
                     {
                         Title = "GHOSTBUSTERS",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "COMEDY",
                         Price = 8.99M,
                         Rating = "G"
                    },

                      new Movie
                      {
                          Title = "GHOSTBUSTERS 2",
                          ReleaseDate = DateTime.Parse("1989-2-23"),
                          Genre = "COMEDY",
                          Price =9.99M,
                          Rating = "G"
                      },

                      new Movie
                      {
                          Title = "RÍO BRAVO",
                          ReleaseDate = DateTime.Parse("1959-4-15"),
                          Genre = "WESTER",
                          Price = 3.99M,
                          Rating = "NA"
                      }
                  ) ;
                context.SaveChanges();
            }
        }
    }
}
