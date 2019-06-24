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
    public class IndexModel : PageModel
    {
        private readonly MovieApp.Models.MovieAppContext _context;

        public IndexModel(MovieApp.Models.MovieAppContext context)
        {
            _context = context;
        }

        public IList<MovieClass> MovieClass { get;set; }

        public async Task OnGetAsync()
        {
            MovieClass = await _context.MovieClass.ToListAsync();
        }
    }
}
