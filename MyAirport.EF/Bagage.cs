using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCSP.MyAirport.EF
{
    public class Bagage
    {
        public Bagage()
        {

        }
        [Column("ID_BAGAGE")]
        public int BagageId { get; set; }
        public int? VolId { get; set; }
        public virtual Vol Vol { get; set; } = null!;

        [Column(TypeName = "char(12)")]
        public string CodeIata { get; set; } = null!;
        

        public DateTime DateCreation { get; set; }

        [Column(TypeName = "char(1)")]
        public string? Classe { get; set; }

        public bool? Prioritaire { get; set; }

        [Column(TypeName = "char(1)")]
        public char? Sta { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Ssur { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Destination { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Escale { get; set; }
    }
}
