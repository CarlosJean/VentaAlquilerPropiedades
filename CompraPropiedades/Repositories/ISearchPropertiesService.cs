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
        Array GetProvincias();
        Array GetSectores(int idProvincia);
        Array GetPropertyTypes();
        Array GetPublicationTypes();
        Array GetPublications(float[] price , int propertyType, List<int> publicationTypes, int rownumberFrom, int rownumberTo, /*int province,*/ int sector);

    }
}