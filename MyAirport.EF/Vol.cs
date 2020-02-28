using System;
using System.Collections.Generic;
using System.Text;

namespace MCSP.MyAirport.EF
{
    public class Vol
    {
        public Vol()
        {

        }
        public int VolId { get; set; }
        public string Cie { get; set; }
        public string Lig { get; set; }
        public DateTime Dhc { get; set; }
        public string Pkg { get; set; }
        public string Imm { get; set; }
        public short Pax { get; set; }
        public string Des { get; set; }


    }
}
