using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class PublicationType
    {
        [Key]
        public int IdPublicationType { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Publication> Publication { get; set; }
        
    }
}