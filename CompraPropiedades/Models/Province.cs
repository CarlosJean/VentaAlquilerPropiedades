using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class Province
    {
        [Key]
        public int IdProvince { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Sector> Sector { get; set; }
        //public virtual ICollection<Publication> Publication { get; set; }

    }
}