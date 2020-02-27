namespace CompraPropiedades.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Publication_Insert",
                p => new
                    {
                        Title = p.String(),
                        Description = p.String(),
                        PublicationDate = p.DateTime(),
                        IdUser = p.Int(),
                        Ubication = p.String(),
                        IdSector = p.Int(),
                        UbicationCoordinates = p.String(),
                        IdPropertyType = p.Int(),
                        Price = p.Single(),
                        IdPublicationType = p.Int(),
                        Available = p.Boolean(),
                        Active = p.Boolean(),
                    },
                body:
                    @"INSERT [dbo].[Publications]([Title], [Description], [PublicationDate], [IdUser], [Ubication], [IdSector], [UbicationCoordinates], [IdPropertyType], [Price], [IdPublicationType], [Available], [Active])
                      VALUES (@Title, @Description, @PublicationDate, @IdUser, @Ubication, @IdSector, @UbicationCoordinates, @IdPropertyType, @Price, @IdPublicationType, @Available, @Active)
                      
                      DECLARE @IdPublication int
                      SELECT @IdPublication = [IdPublication]
                      FROM [dbo].[Publications]
                      WHERE @@ROWCOUNT > 0 AND [IdPublication] = scope_identity()
                      
                      SELECT t0.[IdPublication]
                      FROM [dbo].[Publications] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[IdPublication] = @IdPublication"
            );
            
            CreateStoredProcedure(
                "dbo.Publication_Update",
                p => new
                    {
                        IdPublication = p.Int(),
                        Title = p.String(),
                        Description = p.String(),
                        PublicationDate = p.DateTime(),
                        IdUser = p.Int(),
                        Ubication = p.String(),
                        IdSector = p.Int(),
                        UbicationCoordinates = p.String(),
                        IdPropertyType = p.Int(),
                        Price = p.Single(),
                        IdPublicationType = p.Int(),
                        Available = p.Boolean(),
                        Active = p.Boolean(),
                    },
                body:
                    @"UPDATE [dbo].[Publications]
                      SET [Title] = @Title, [Description] = @Description, [PublicationDate] = @PublicationDate, [IdUser] = @IdUser, [Ubication] = @Ubication, [IdSector] = @IdSector, [UbicationCoordinates] = @UbicationCoordinates, [IdPropertyType] = @IdPropertyType, [Price] = @Price, [IdPublicationType] = @IdPublicationType, [Available] = @Available, [Active] = @Active
                      WHERE ([IdPublication] = @IdPublication)"
            );
            
            CreateStoredProcedure(
                "dbo.Publication_Delete",
                p => new
                    {
                        IdPublication = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Publications]
                      WHERE ([IdPublication] = @IdPublication)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Publication_Delete");
            DropStoredProcedure("dbo.Publication_Update");
            DropStoredProcedure("dbo.Publication_Insert");
        }
    }
}
