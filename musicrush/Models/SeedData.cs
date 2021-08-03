using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace musicrush.Models
{
    public static class SeedData
    {
        static Album[] Albums = new Album[]
                {
                   new Album
                    {
                        Title = "Movin",
                        ReleaseDate = DateTime.Parse("2019-1-18"),
                        Genre = "R&B",
                        Artist = "Samm Henshaw",
                        Rating = 4
                    },
                    new Album
                    {                    
                        Title = "Case of Mondays",
                        ReleaseDate = DateTime.Parse("2019-4-10"),
                        Genre = "Rap",
                        Artist = "Tierra Whack",
                        Rating = 5
                    },
                    new Album
                    {                    
                        Title = "Little Big",
                        ReleaseDate = DateTime.Parse("2018-8-03"),
                        Genre = "Rap",
                        Artist = "Watsky",
                        Rating = 1
                    }
                };

        static Song[] Songs = new Song[]{
                    new Song
                    {
                        Title = "WannaBe",
                        // Album = Albums[0],
                        // AlbumId = Albums[0].ID,
                        AlbumId = 1,
                        ReleaseDate = DateTime.Parse("2019-1-18"),
                        Genre = "R&B",
                        Artist = "Samm Henshaw",
                        Rating = 4
                    },
                    new Song
                    {
                        Title = "Kicking It",
                        // Album = Albums[1],
                        // AlbumId = Albums[1].ID,
                        AlbumId = 2,
                        ReleaseDate = DateTime.Parse("2019-4-10"),
                        Genre = "Rap",
                        Artist = "Tierra Whack",
                        Rating = 5
                    },
                    new Song
                    {
                        Title = "Link",
                        // Album = Albums[1],
                        // AlbumId = Albums[1].ID,
                        AlbumId = 2,
                        ReleaseDate = DateTime.Parse("2021-4-06"),
                        Genre = "Hip-Hop",
                        Artist = "Tierra Whack",
                        Rating = 2
                    },
                    new Song
                    {
                        Title = "Link 2",
                        // Album = Albums[1],
                        // AlbumId = Albums[1].ID,
                        AlbumId = 2,
                        ReleaseDate = DateTime.Parse("2021-4-06"),
                        Genre = "Hip-Hop",
                        Artist = "Tierra Whack",
                        Rating = 2
                    },
                    new Song
                    {
                        Title = "Link 3",
                        // Album = Albums[1],
                        // AlbumId = Albums[1].ID,
                        AlbumId = 2,
                        ReleaseDate = DateTime.Parse("2021-4-06"),
                        Genre = "Hip-Hop",
                        Artist = "Tierra Whack",
                        Rating = 2
                    },
                    new Song
                    {
                        Title = "Welcome to the Family 1",
                        // Album = Albums[2],
                        // AlbumId = Albums[2].ID,
                        AlbumId = 3,
                        ReleaseDate = DateTime.Parse("2018-8-03"),
                        Genre = "Rap",
                        Artist = "Watsky",
                        Rating = 1
                    },
                    new Song
                    {
                        Title = "Welcome to the Family 2",
                        // Album = Albums[2],
                        // AlbumId = Albums[2].ID,
                        AlbumId = 3,
                        ReleaseDate = DateTime.Parse("2018-8-03"),
                        Genre = "Rap",
                        Artist = "Watsky",
                        Rating = 1
                    },
                    new Song
                    {
                        Title = "Welcome to the Family 3",
                        // Album = Albums[2],
                        // AlbumId = Albums[2].ID,
                        AlbumId = 3,
                        ReleaseDate = DateTime.Parse("2018-8-03"),
                        Genre = "Rap",
                        Artist = "Watsky",
                        Rating = 1
                    },
                    new Song
                    {
                        Title = "Welcome to the Family 3",
                        // Album = Albums[2],
                        // AlbumId = Albums[2].ID,
                        AlbumId = 3,
                        ReleaseDate = DateTime.Parse("2018-8-03"),
                        Genre = "Rap",
                        Artist = "Watsky",
                        Rating = 1
                    }
                };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesSongContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesSongContext>>()))
            {
                // Look for any Songs.
                if (context.Songs.Any())
                {
                    return;   // DB has been seeded
                }

                // Albums[0].Songs.Append(Songs[0]);
                // Albums[1].Songs.Append(Songs[1]);
                // Albums[1].Songs.Append(Songs[2]);
                // Albums[2].Songs.Append(Songs[3]);
                
                context.Songs.AddRange(Songs);
                context.SaveChanges();
                context.Albums.AddRange(Albums);
                // foreach(Album a: Albums) {
                //     foreach(Song s: Songs) {
                //         if (s.Album == a) {
                //             a.Songs.add(s);
                //         }
                //     }
                // }
                context.SaveChanges();
            }
        }
    }
}