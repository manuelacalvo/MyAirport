using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCSP.MyAirport.EF
{
    /// <summary>
    /// Objet Bagage
    /// </summary>
    public class Bagage
    {
        
        public Bagage()
        {

        }
        [Column("ID_BAGAGE")]
        /// <summary>
        /// id clé primaire de l'objet bagage
        /// </summary>
        public int BagageId { get; set; }
        public int? VolId { get; set; }
        public virtual Vol Vol { get; set; } = null!;

        [Column(TypeName = "char(12)")]
        /// <summary>
        /// Code iata du bagage, unique à un instant t
        /// </summary>
        public string CodeIata { get; set; } = null!;

        /// <summary>
        /// date a laquelle le bagage a été créé
        /// </summary>
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
