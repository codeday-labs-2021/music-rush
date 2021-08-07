using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using musicrush.Models;

namespace musicrush.Pages.Songs
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesSongContext _context;

        public CreateModel(RazorPagesSongContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; }

        [BindProperty]

        public String AlbumTitle { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (String.IsNullOrWhiteSpace(AlbumTitle)) {
                return RedirectToPage("/Error?AlbumTitleEmpty=true");
            }

            Album album = _context
                            .Albums
                            .Where(a => a.Title.ToLower().Equals(AlbumTitle.ToLower()))
                            .FirstOrDefault();

            if (album == null) {
                return RedirectToPage("/Error?AlbumNotFound=" + HttpUtility.UrlEncode('"' + AlbumTitle + '"'));
            }

            Song.Album = album;
            Song.AlbumId = album.ID;
            _context.Songs.Add(Song);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
