using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Data;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace musicrush.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesSongContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesSongContext>>()))
            {
                // Look for any Songs.
                if (context.Song.Any())
                {
                    return;   // DB has been seeded
                }

                context.Song.AddRange(
                    new Song
                    {
                        Title = "Church",
                        ReleaseDate = DateTime.Parse("2019-1-18"),
                        Genre = "R&B",
                        Artist = "Samm Henshaw"
                    },

                    new Song
                    {
                        Title = "Unemployed",
                        ReleaseDate = DateTime.Parse("2019-4-10"),
                        Genre = "Rap",
                        Artist = "Tierra Whack"
                    },

                    new Song
                    {
                        Title = "Link",
                        ReleaseDate = DateTime.Parse("2021-4-06"),
                        Genre = "Hip-Hop",
                        Artist = "Tierra Whack"
                    },

                    new Song
                    {
                        Title = "Welcome to the Family",
                        ReleaseDate = DateTime.Parse("2018-8-03"),
                        Genre = "Western",
                        Artist = "Watsky"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}