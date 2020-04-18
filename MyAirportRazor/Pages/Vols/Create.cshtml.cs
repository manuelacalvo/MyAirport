using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MCSP.MyAirport.EF;

namespace MCSP.MyAirport.Razor.Pages_Vols_
{
    public class CreateModelVol : PageModel
    {
        private readonly MCSP.MyAirport.EF.MyAirportContext _context;

        public CreateModelVol(MCSP.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vol Vol { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vols.Add(Vol);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
