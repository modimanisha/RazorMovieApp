using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp;
using MovieApp.Models;

namespace MovieApp.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly MovieApp.Models.MovieAppContext _context;

        public EditModel(MovieApp.Models.MovieAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MovieClass MovieClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieClass = await _context.MovieClass.FirstOrDefaultAsync(m => m.ID == id);

            if (MovieClass == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieClassExists(MovieClass.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieClassExists(int id)
        {
            return _context.MovieClass.Any(e => e.ID == id);
        }
    }
}
