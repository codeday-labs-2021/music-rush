using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using musicrush.Models;

namespace musicrush.Pages.Songs
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesSongContext _context;

        public DeleteModel(RazorPagesSongContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song = await _context.Songs.FirstOrDefaultAsync(m => m.ID == id);

            if (Song == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song = await _context.Songs.FindAsync(id);

            if (Song != null)
            {
                _context.Songs.Remove(Song);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
