using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class Precio
    {
        [Key]
        public int IdPrecio { get; set; }
        public string Descripcion { get; set; }
    }
}