using System;
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
                var listadoPrecios = this._db.Price.ToArray();
                return listadoPrecios;
        }

        public Array GetProvincias() {
            var listadoProvincias = this._db.Province.ToArray();
            return listadoProvincias;
        }

        public Array GetSectores(int idProvincia)
        {
            var listadoSectores = (from s in this._db.Sector
                                   join p in this._db.Province on s.IdProvince equals p.IdProvince
                                   where s.IdProvince == idProvincia
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

        public Array GetPublications(float[] price, int propertyType, List<int> publicationTypes, int rownumberFrom, int rownumberTo, /*int province = 0,*/ int sector = 0)
        {

            var priceFrom = price[0];
            var priceTo   = price[1];
            var rowNumber = 1;

            var p1 = (from P in this._db.Publication
                                       // join PR in this._db.Province on P.IdProvince equals PR.IdProvince
                                       // join S  in this._db.Sectors   on PR.IdProvince equals S.IdProvince
                                        where P.Price >= priceFrom && P.Price <= priceTo && P.PropertyType.IdPropertyType == propertyType && 
                                        publicationTypes.Contains(P.PublicationType.IdPublicationType) /*&& P.IdProvince == province*/ && P.IdSector == sector
                                        
            
                      select new { P.IdPublication, P.Title, PublicationDescription = P.Description,
                                            Image= (from PI1 in this._db.PublicationImage
                                             where PI1.IdPublication == P.IdPublication
                                             select new { PI1.Image}
                                             ).Take(1)/*,Province=PR.Description, Sector = S.Description*/, PropertyPrice = P.Price}).ToList();

            var p2 = (from PL
                    in p1
                      select new { PL.IdPublication, PL.Title, PL.PublicationDescription, PL.Image, PL.PropertyPrice, RowNumber = rowNumber++ }).ToArray();


            
            var publicationsList = (from PL
                                in p2
                                where PL.RowNumber >= rownumberFrom && PL.RowNumber <= rownumberTo
                                    select p2
                                ).ToArray();

            return publicationsList;
        }
    }
    }
