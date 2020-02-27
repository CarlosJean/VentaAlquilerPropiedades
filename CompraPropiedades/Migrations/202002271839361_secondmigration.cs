namespace CompraPropiedades.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("dbo.Publication_Insert");
            DropStoredProcedure("dbo.Publication_Update");
            DropStoredProcedure("dbo.Publication_Delete");
        }
        
        public override void Down()
        {
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
