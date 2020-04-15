using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MCSP.MyAirport.EF;

namespace MCSP.MyAirport.Razor.Pages_Vols_
{
    public class IndexModel : PageModel
    {
        private readonly MCSP.MyAirport.EF.MyAirportContext _context;

        public IndexModel(MCSP.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList<Vol> Vol { get;set; }

        public async Task OnGetAsync()
        {
            Vol = await _context.Vols.ToListAsync();
        }
    }
}
