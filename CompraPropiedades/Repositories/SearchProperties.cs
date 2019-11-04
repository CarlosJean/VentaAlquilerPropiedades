using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompraPropiedades.Models;

namespace CompraPropiedades.Repositories
{
    public class SearchProperties:ISearchPropertiesService
    {
        private readonly VentaPropiedadesContext _db;

        public SearchProperties()
        {
            this._db = new VentaPropiedadesContext();
        }

        public Array GetPrecios()
        {
                var listadoPrecios = this._db.Precios.ToArray();
                return listadoPrecios;
        }

        public Array GetProvincias() {
            var listadoProvincias = this._db.Provincias.ToArray();
            return listadoProvincias;
        }

        public Array GetSectores(int idProvincia)
        {
            var listadoSectores = (from s in this._db.Sectores
                                   join p in this._db.Provincias on s.IdProvincia equals p.IdProvincia
                                   where s.IdProvincia == idProvincia
                                   select s/*new  Sector{ IdSector = s.IdSector, Descripcion = s.Descripcion,Provincia= p}*/).ToArray();
            return listadoSectores;
        }


        public Array GetPropertyTypes() {

            var propertyTypeList = (from PT in this._db.PropertyType
                                   select PT).ToArray();

            return propertyTypeList;
        }

        public Array GetPublicationTypes()
        {

            var publicationTypesList = (from PT in this._db.PublicationType
                                        select PT).ToArray();

            return publicationTypesList;
        }

        public Array GetPublications(float[] price, int propertyType, List<int> publicationTypes, int province = 0, int sector = 0)
        {

            var priceFrom = price[0];
            var priceTo   = price[1];

            IEnumerable publicationTypesList = new IEnumerable();

            if (propertyType == null) {
                publicationTypesList = (from P in this._db.Publication
                                        join PR in this._db.Provincias on P.IdProvince equals PR.IdProvincia
                                        join S in this._db.Sectores on PR.IdProvincia equals S.IdProvincia
                                        where P.Price >= priceFrom && P.Price <= priceTo && P.PropertyType.IdPropertyType == propertyType &&
                                        publicationTypes.Contains(P.PublicationType.IdPublicationType) && P.IdProvince == province && P.IdSector == sector
                                        select new
                                        {
                                            P.IdPublication,
                                            P.Title,
                                            PublicationDescription = P.Description,
                                            PublicationImage = (from PI1 in this._db.PublicationImage
                                                                where PI1.IdPublication == P.IdPublication
                                                                select new { PI1.Image }
                                             ).Take(1),
                                            Province = PR.Descripcion,
                                            Sector = S.Descripcion,
                                            P.Price
                                        })/*.ToArray()*/;
            }
            elseif()
                {

                }

             

            return publicationTypesList;
        }
    }
    }
