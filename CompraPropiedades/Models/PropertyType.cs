using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class PropertyType
    {
        [Key]
        public int IdPropertyType { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Publication> Publication { get; set; }
    }
}