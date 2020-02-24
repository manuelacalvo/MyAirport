using System;
using System.Collections.Generic;
using System.Text;

namespace MCSP.MyAirport.EF
{
    class Bagage
    {
        public int BagageId { get; set; }
        public int VolId { get; set; }
        public Vol Vol { get; set; }
        public string CodeIata { get; set; }
        public DateTime DateCreation { get; set; }
        public char Classe { get; set; }
        public bool Prioritaire { get; set; }
        public char Sta { get; set; }
        public string Ssur { get; set; }
        public string Destination { get; set; }
        public string Escale { get; set; }
    }
}
