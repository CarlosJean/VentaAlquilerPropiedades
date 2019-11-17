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

        public DbSet<Price> Price { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<Publication> Publication { get; set; }
        public DbSet<PublicationImage> PublicationImage { get; set; }
        public DbSet<PublicationType> PublicationType { get; set; }


    }
}