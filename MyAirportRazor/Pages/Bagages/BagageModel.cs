using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MCSP.MyAirport.EF;

namespace MCSP.MyAirport.Razor
{
    public class BagageModel : PageModel
    {
        class monVol
        {
            public int? VolId { get; set; }
            public string Description { get; set; }
        }
        protected SelectList SelectListVols
        {
            get
            {

                var vols =
             _context.Vols
             .Select(v => new
             {
                 v.VolId,
                 Description = $"{v.Cie} {v.Lig} : {v.Dhc.ToString()}"
             })
             .ToList();
               vols.Insert(vols.Count, new { VolId = -1, Description = "N/A" });
               

                return new SelectList(vols, "VolId", "Description");

            }
        }

        protected readonly MyAirportContext _context;

            public BagageModel(MyAirportContext context)
        {
            _context = context;
        }
        }
    }

