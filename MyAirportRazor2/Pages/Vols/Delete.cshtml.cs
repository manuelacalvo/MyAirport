﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MCSP.MyAirport.EF;

namespace MCSP.MyAirport.Razor.Pages_Vols_
{
    public class DeleteModel : PageModel
    {
        private readonly MCSP.MyAirport.EF.MyAirportContext _context;

        public DeleteModel(MCSP.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vol = await _context.Vols.FindAsync(id);

            if (Vol != null)
            {
                _context.Vols.Remove(Vol);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}