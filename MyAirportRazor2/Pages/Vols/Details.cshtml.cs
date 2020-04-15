using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MCSP.MyAirport.EF;

namespace MCSP.MyAirport.Razor
{
    public class DetailsModel : PageModel
    {
        private readonly MCSP.MyAirport.EF.MyAirportContext _context;

        public DetailsModel(MCSP.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public Vol Vol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vol = await _context.Vols.FirstOrDefaultAsync(m => m.VolId == id);

            if (Vol == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
