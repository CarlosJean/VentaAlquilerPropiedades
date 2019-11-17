using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class Price
    {
        [Key]
        public int IdPrice { get; set; }
        public string Description { get; set; }
    }
}