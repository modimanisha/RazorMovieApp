using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieApp;
using MovieApp.Models;

namespace MovieApp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly MovieApp.Models.MovieAppContext _context;

        public DetailsModel(MovieApp.Models.MovieAppContext context)
        {
            _context = context;
        }

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
    }
}
