using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Blade Runner",
                        ReleaseDate = DateTime.Parse("25-6-1982"),
                        Genre = "SciFi/Ação/Fantasia",
                        Price = 28M
                    },

                    new Movie
                    {
                        Title = "Blade Runner 2049 ",
                        ReleaseDate = DateTime.Parse("3-10-2017"),
                        Genre = "SciFi/Thriller",
                        Price = 185M
                    },

                    new Movie
                    {
                        Title = "Rambo",
                        ReleaseDate = DateTime.Parse("22-10-1982"),
                        Genre = "Ação/Drama",
                        Price = 15M
                    },

                    new Movie
                    {
                        Title = "Escola Do Rock",
                        ReleaseDate = DateTime.Parse("3-10-2003"),
                        Genre = "Comédia",
                        Price = 35M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
