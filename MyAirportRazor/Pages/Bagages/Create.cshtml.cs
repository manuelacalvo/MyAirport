using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MCSP.MyAirport.EF;
using MCSP.MyAirport.Razor.Pages.Bagages;

namespace MCSP.MyAirport.Razor.Pages.Bagages
{
    public class CreateModelBagage : BagageModel
    {
        public CreateModelBagage(MyAirport.EF.MyAirportContext context) : base(context) { }
        public IActionResult OnGet()
        {
            ViewData["VolInfo"] = SelectListVols;
            return Page();
        }

        [BindProperty]
        public Bagage Bagage { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["VolInfo"] = SelectListVols;
                return Page();
            }

           if(Bagage.VolId == -1)
            {
                Bagage.VolId = null;
                Bagage.Vol = null;
            }

            _context.Bagages.Add(Bagage);
            await _context.SaveChangesAsync();

            
            return RedirectToPage("./Details", new { id = Bagage.BagageId});
        }
    }
}
