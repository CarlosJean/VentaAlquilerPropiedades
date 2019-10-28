using CompraPropiedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Repositories
{
    public interface ISearchPropertiesService
    {
        Array GetPrecios();
    }
}