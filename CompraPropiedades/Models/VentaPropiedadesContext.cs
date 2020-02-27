using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CompraPropiedades.Models
{
    public class VentaPropiedadesContext:DbContext

    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //modelBuilder.Entity<Publication>()
            //            .MapToStoredProcedures();
        }

        public VentaPropiedadesContext():base("CompraPropiedades")
            {

        }
        public DbSet<Acommodation> Accomodation { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<Publication> Publication { get; set; }
        public DbSet<PublicationImage> PublicationImage { get; set; }
        public DbSet<PublicationType> PublicationType { get; set; }
        public DbSet<PublicationAcommodation> PublicationAccomodation { get; set; }

        public virtual HidePublication SpHidePublication(int idPublication_IN) {

            var codError = new SqlParameter() {
                ParameterName = "codError",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var msjError = new SqlParameter() {
                ParameterName = "msjError",
                SqlDbType = SqlDbType.NVarChar,
                Size = 200,
                Direction = ParameterDirection.Output
            };

            this.Database.ExecuteSqlCommand("spHidePublication @idPublication_IN,@codError OUT,@msjError OUT",
                                                                                   new SqlParameter("idPublication_IN", idPublication_IN),
                                                                                   codError,
                                                                                   msjError);
            HidePublication hidePublication = new HidePublication() {
                Code = (int)codError.Value,
                Status = (string)msjError.Value
            };

            return hidePublication;
        }

        public virtual HidePublication SpShowPublication(int idPublication_IN) {

            var codError = new SqlParameter() {
                ParameterName = "codError",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var msjError = new SqlParameter() {
                ParameterName = "msjError",
                SqlDbType = SqlDbType.NVarChar,
                Size = 200,
                Direction = ParameterDirection.Output
            };

            this.Database.ExecuteSqlCommand("spShowPublication @idPublication_IN,@codError OUT,@msjError OUT",
                                                                                   new SqlParameter("idPublication_IN", idPublication_IN),
                                                                                   codError,
                                                                                   msjError);
            HidePublication hidePublication = new HidePublication() {
                Code = (int)codError.Value,
                Status = (string)msjError.Value
            };

            return hidePublication;
        }

    }
}