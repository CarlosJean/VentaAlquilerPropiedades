using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class VentaPropiedadesContext:DbContext

    {
        public VentaPropiedadesContext():base("CompraPropiedades")
            {

        }

        public DbSet<Precio> Precios { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Sector> Sectores{ get; set; }


    }
}