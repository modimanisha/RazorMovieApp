using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp;
using MovieApp.Models;

namespace MovieApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieApp.Models.MovieAppContext _context;

        public CreateModel(MovieApp.Models.MovieAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MovieClass MovieClass { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MovieClass.Add(MovieClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}