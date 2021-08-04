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
        private readonly RazorPagesSongContext _context;

        public IndexModel(RazorPagesSongContext context)
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
            IQueryable<string> genreQuery = from a in _context.Albums
                                            orderby a.Genre
                                            select a.Genre;
            IQueryable<string> artistQuery = from a in _context.Albums
                                            orderby a.Artist
                                            select a.Artist;
           
            var albums = from a in _context.Albums
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
