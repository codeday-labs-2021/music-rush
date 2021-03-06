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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesSongContext _context;

        public DetailsModel(RazorPagesSongContext context)
        {
            _context = context;
        }

        public Album Album { get; set; }

        // public String StarRating { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context
                            .Albums
                            .Include(a => a.Songs)
                            .FirstOrDefaultAsync(m => m.ID == id);

            if (Album == null)
            {
                return NotFound();
            }

            // StarRating = new String( '✭', Album.Rating ?? 0);
            
            return Page();
        }
    }
}
