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
                var listadoPrecios = this._db.Precios.ToArray();
                return listadoPrecios;
        }

        public Array GetProvincias() {
            var listadoProvincias = this._db.Provincias.ToArray();
            return listadoProvincias;
        }

        public IEnumerable<Sector> GetSectores(int idProvincia)
        {
            var listadoSectores = (from s in this._db.Sectores
                                   join p in this._db.Provincias on s.IdProvincia equals p.IdProvincia
                                   where s.IdProvincia == idProvincia
                                   select s/*new  Sector{ IdSector = s.IdSector, Descripcion = s.Descripcion,Provincia= p}*/).ToList();
            return listadoSectores;
        }


    }
    }
