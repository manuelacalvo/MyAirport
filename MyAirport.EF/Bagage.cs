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
        /// <summary>
        /// Constructeur par défault Bagage
        /// </summary>
        public Bagage()
        {

        }

        /// <summary>
        /// Constructeur surchargé du bagage
        /// </summary>
        public Bagage(string code_iata, DateTime creation)
        {
            CodeIata = code_iata;
            DateCreation = creation;
        }

        /// <summary>
        /// id clé primaire de l'objet bagage
        /// </summary>
        [Column("ID_BAGAGE")]
        public int BagageId { get; set; }

        /// <summary>
        /// id clé étrangère de l'objet vol
        /// </summary>
        public int? VolId { get; set; }

        /// <summary>
        /// Jointure: ppté de navigation vers un vol
        /// </summary>
        public virtual Vol? Vol { get; set; } = null!;

       
        /// <summary>
        /// Code iata du bagage, unique à un instant t
        /// </summary> 
        [Column(TypeName = "char(12)")]
        public string CodeIata { get; set; } = null!;

        /// <summary>
        /// date a laquelle le bagage a été créé
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Classe du bagage
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string? Classe { get; set; }

        /// <summary>
        /// bagage prioritaire ou non
        /// </summary>
        public bool? Prioritaire { get; set; }

        /// <summary>
        /// status du bagage
        /// </summary>
        [Column(TypeName = "char(1)")]
        public char? Sta { get; set; }

        /// <summary>
        /// sureté du bagage
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Ssur { get; set; }

        /// <summary>
        /// Destination du bagage
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Destination { get; set; }

        /// <summary>
        /// Escale du bagage
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Escale { get; set; }
    }
}
