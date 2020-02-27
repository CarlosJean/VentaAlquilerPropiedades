using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //[StringLength(500, ErrorMessage = "User name is too short", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe especificar un título.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Debe especificar una descripción.")]
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public int IdUser { get; set; }
        public string Ubication { get; set; }
        //[ForeignKey("Province")]
        //public int IdProvince { get; set; }
        //[ForeignKey("Sector")]
        [Required(ErrorMessage = "Debe especificar un sector.")]
        [DataType(DataType.Text)]
        public int? IdSector { get; set; }
        public string UbicationCoordinates { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un tipo de propiedad.")]
        public int IdPropertyType { get; set; }
        [Required(ErrorMessage = "Debe especificar un precio.")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Debe especificar un tipo de publicación.")]
        public int? IdPublicationType { get; set; }

        [DefaultValue(true)]
        public bool Available { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual PropertyType PropertyType { get; set; }

        [JsonIgnore]
        //[Required(ErrorMessage = "Debe especificar un tipo de publicación.")]
        public virtual ICollection<PublicationImage> PublicationImage { get; set; }

        [JsonIgnore]
        public virtual PublicationType PublicationType { get; set; }
        //[JsonIgnore]
        //public virtual Province Province { get; set; }
        [JsonIgnore]
        
        public virtual Sector  Sector { get; set; }

        [JsonIgnore]
        public virtual ICollection<PublicationAcommodation> PublicationAcommodations { get; set; }


    }
}