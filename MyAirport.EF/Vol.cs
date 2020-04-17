using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCSP.MyAirport.EF
{
    /// <summary>
    /// Classe du vol
    /// </summary>
    public class Vol
    {
        /// <summary>
        /// Constructeur vide du vol
        /// </summary>
        public Vol()
        {
            this.Bagages = new List<Bagage>();
        }

        /// <summary>
        /// Constructeur surchargé du vol
        /// </summary>
        public Vol(string compagnie, string line, DateTime dhc)
        {
            Cie = compagnie;
            Lig = line;
            Dhc = dhc;
            this.Bagages = new List<Bagage>();
        }

        /// <summary>
        /// Clé primaire id du vol
        /// </summary>
        [Column("ID_VOL")]
        public int VolId { get; set; }

        /// <summary>
        /// Compagnie du vol
        /// </summary>
        [Column(TypeName = "char(5)")]
        public string Cie { get; set; } = null!;

        /// <summary>
        /// Ligne du vol
        /// </summary>
        [Column(TypeName = "varchar(5)")]
        public string Lig { get; set; } = null!;

        /// <summary>
        /// DHC du vol
        /// </summary>
        public DateTime? Dhc { get; set; }

        /// <summary>
        /// Parking du vol
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Pkg { get; set; }

        /// <summary>
        /// Immatriculation du vol
        /// </summary>
        [Column(TypeName = "char(6)")]
        public string? Imm { get; set; }

        /// <summary>
        /// Nombre de passagers du vol
        /// </summary>
        public short? Pax { get; set; }

        /// <summary>
        /// Destination du vol
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Des { get; set; }


        /// <summary>
        /// Collection de bagage virtuel du vol
        /// </summary>
        public virtual ICollection<Bagage> Bagages { get; set; }
    }
}
