using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompraPropiedades.Models;

namespace CompraPropiedades.ViewModels
{
    public class MyPublicationsViewModel{

        //public List<Publication> publications { get; set; }
        //public List<PublicationImage> publicationImages { get; set; }

        public int PublicationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Available { get; set; }
        public bool Active { get; set; }
    }
}