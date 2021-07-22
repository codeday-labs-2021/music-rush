using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IList<Album> Album { get;set; }

        public async Task OnGetAsync()
        {
            Album = await _context.Album.ToListAsync();
        }
    }
}
