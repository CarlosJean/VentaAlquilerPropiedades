using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class Acommodation
    {
        [Key]
        public virtual int IdAcommodation { get; set; }

        public virtual string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<PublicationAcommodation> PublicationAcommodations { get; set; }
    }
}