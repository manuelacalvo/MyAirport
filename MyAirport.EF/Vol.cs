using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCSP.MyAirport.EF
{
    public class Vol
    {
        public Vol()
        {
            this.Bagages = new List<Bagage>();
        }
        [Column("ID_VOL")]
        public int VolId { get; set; }

        [Column(TypeName = "char(5)")]
        public string Cie { get; set; } = null!;

        [Column(TypeName = "varchar(5)")]
        public string Lig { get; set; } = null!;

        public DateTime? Dhc { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Pkg { get; set; }

        [Column(TypeName = "char(6)")]
        public string? Imm { get; set; }

        public short? Pax { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Des { get; set; }

        

        public virtual ICollection<Bagage> Bagages { get; set; }
    }
}
