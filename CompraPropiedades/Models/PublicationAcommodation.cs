using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class PublicationAcommodation
    {
        [Key]
        public int IdAcommodationPublication { get; set; }

        public int IdAcommodation { get; set; }

        public int IdPublication { get; set; }

        public int Quantity { get; set; }

        [JsonIgnore]
        public virtual Acommodation Acommodations { get; set; }
        [JsonIgnore]
        public virtual Publication Publications { get; set; }
    }
}