using CompraPropiedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompraPropiedades.ViewModels
{
    public class PostViewModel
    {

        public Publication Publication { get; set; }

        public List<HttpPostedFileBase> PublicationImage { get; set; }
        public List<string> Accomodations { get; set; }

    }
}