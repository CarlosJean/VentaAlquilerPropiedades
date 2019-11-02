using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Sector> Sector { get; set; }
        public virtual ICollection<Publication> Publication { get; set; }

    }
}