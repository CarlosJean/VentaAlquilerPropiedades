using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompraPropiedades.ViewModels
{
    public class PublicationViewModel
    {

        public int IdPublication { get; set; }
        public string Title { get; set; }
        public List<string> Images { get; set; }

        public string Description { get; set; }
        public float Price { get; set; }

        public string Username { get; set; }

    }
}