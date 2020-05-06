using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asp_Ghiuzan_Denis_Rp.Data;
using Asp_Ghiuzan_Denis_Rp.Models;

namespace Asp_Ghiuzan_Denis_Rp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly Asp_Ghiuzan_Denis_Rp.Data.Asp_Ghiuzan_Denis_RpContext _context;

        public DetailsModel(Asp_Ghiuzan_Denis_Rp.Data.Asp_Ghiuzan_Denis_RpContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
