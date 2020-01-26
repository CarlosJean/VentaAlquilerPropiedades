using CompraPropiedades.Models;
using CompraPropiedades.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Repositories
{
    public interface IPublicationService
    {
        List<Acommodation> GetAccomodations();
        void RegisterPublication(PostViewModel postViewModel);
    }
}