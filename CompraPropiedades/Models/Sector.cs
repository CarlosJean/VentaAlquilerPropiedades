﻿using Newtonsoft.Json;
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
        public string Description { get; set; }
        public int IdProvince { get; set; }

        [JsonIgnore]
        public virtual Province Province { get; set; }

        public virtual ICollection<Publication> Publication { get; set; }

    }
}