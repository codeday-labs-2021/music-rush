using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using musicrush.Models;

namespace musicrush.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesSongContext _context;

        public IndexModel(RazorPagesSongContext context)
        {
            _context = context;
        }
        public IList<Song> Song { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SongGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from s in _context.Songs
                                            orderby s.Genre
                                            select s.Genre;
            var songs = from s in _context.Songs
                        select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(s => s.Title.ToUpper().Contains(SearchString.ToUpper()));
            }
            if (!string.IsNullOrEmpty(SongGenre))
            {
                songs = songs.Where(x => x.Genre == SongGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Song = await songs.ToListAsync();
        }
    }
}
