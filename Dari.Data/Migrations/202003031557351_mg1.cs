namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annonces",
                c => new
                    {
                        AnnonceId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        address = c.String(),
                        surface = c.Single(nullable: false),
                        chambres = c.Int(nullable: false),
                        images = c.String(),
                    })
                .PrimaryKey(t => t.AnnonceId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.IdClient);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
            DropTable("dbo.Annonces");
        }
    }
}
