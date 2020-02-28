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
        [Key]
        public int VolId { get; set; }
        [Column(TypeName = "varchar()")]
        public string Cie { get; set; }
        public string Lig { get; set; }
        public DateTime Dhc { get; set; }
        public string Pkg { get; set; }
        public string Imm { get; set; }
        public short Pax { get; set; }
        public string Des { get; set; }

        

        public virtual ICollection<Bagage> Bagages { get; set; }
    }
}
