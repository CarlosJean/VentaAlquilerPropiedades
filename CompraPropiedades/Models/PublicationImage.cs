using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class PublicationImage
    {
        [Key]
        public int IdPublicationImage { get; set; }

        public int IdPublication { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        public virtual List<Publication> Publication { get; set; }
    }
}