using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class Sector
    {
        [Key]
        public int IdSector { get; set; }
        public string Descripcion { get; set; }
        public int IdProvincia { get; set; }
        [JsonIgnore]
        public virtual Provincia Provincia { get; set; }
    }
}