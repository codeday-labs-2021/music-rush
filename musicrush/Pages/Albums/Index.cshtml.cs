using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using musicrush.Models;

namespace musicrush.Pages.Albums
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAlbumContext _context;

        public IndexModel(RazorPagesAlbumContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string AlbumGenre { get; set; }
        public SelectList Artists {get; set;}
        [BindProperty(SupportsGet = true)]
        public string AlbumArtist {get; set; }
        public async Task OnGetAsync()
        {
            //Use LINQ to get list of genres and artists.
            IQueryable<string> genreQuery = from a in _context.Album
                                            orderby a.Genre
                                            select a.Genre;
            IQueryable<string> artistQuery = from a in _context.Album
                                            orderby a.Artist
                                            select a.Artist;
// public async Task OnGetAsync()
// {
//     // Use LINQ to get list of genres.
//     IQueryable<string> genreQuery = from m in _context.Movie
//                                     orderby m.Genre
//                                     select m.Genre;

//     var movies = from m in _context.Movie
//                  select m;

//     if (!string.IsNullOrEmpty(SearchString))
//     {
//         movies = movies.Where(s => s.Title.Contains(SearchString));
//     }

//     if (!string.IsNullOrEmpty(MovieGenre))
//     {
//         movies = movies.Where(x => x.Genre == MovieGenre);
//     }
//     Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
//     Movie = await movies.ToListAsync();
// }            
            var albums = from a in _context.Album
                 select a;
            if (!string.IsNullOrEmpty(SearchString))
            {
                albums = albums.Where(a => a.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(AlbumGenre))
            {
                albums = albums.Where(b => b.Genre == AlbumGenre);
            } 
            if (!string.IsNullOrEmpty(AlbumArtist))  
            {
                albums = albums.Where(c => c.Artist == AlbumArtist);
            }
            SelectList selectList1 = new SelectList(await genreQuery.Distinct().ToListAsync());
            SelectList selectList2 = new SelectList(await artistQuery.Distinct().ToListAsync());            
            Genres = selectList1;
            Artists = selectList2;
            Album = await albums.ToListAsync();
        } 
    }
}
