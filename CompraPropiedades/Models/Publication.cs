using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Ubication { get; set; }
        //[ForeignKey("Province")]
        //public int IdProvince { get; set; }
        //[ForeignKey("Sector")]
        public int IdSector { get; set; }
        public string UbicationCoordinates { get; set; }
        public int IdPropertyType { get; set; }
        public float Price { get; set; }
        public int IdPublicationType { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual PropertyType PropertyType { get; set; }

        [JsonIgnore]
        public ICollection<PublicationImage> PublicationImage { get; set; }

        [JsonIgnore]
        public virtual PublicationType PublicationType { get; set; }
        //[JsonIgnore]
        //public virtual Province Province { get; set; }
        [JsonIgnore]
        public virtual Sector  Sector { get; set; }


    }
}