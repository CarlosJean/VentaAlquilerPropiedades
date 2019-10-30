using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class Publication
    {
        [Key]
        public int IdPublication { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublicationDate { get; set; }

        public int IdUser { get; set; }

        public virtual User User { get; set; }

        public string Ubication { get; set; }

        public string UbicationCoordinates { get; set; }

        public int IdPropertyType { get; set; }

        public virtual PropertyType PropertyType { get; set; }

        public float Price { get; set; }

        [JsonIgnore]
        public ICollection<PublicationImage> PublicationImage { get; set; }
    }
}