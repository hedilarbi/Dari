namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnements",
                c => new
                    {
                        Clientfk = c.Int(nullable: false),
                        Productfk = c.Int(nullable: false),
                        DateAchat = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        TyAbo_IdAbo = c.Int(),
                        Client_IdClient = c.Int(),
                    })
                .PrimaryKey(t => new { t.Clientfk, t.Productfk })
                .ForeignKey("dbo.TyAboes", t => t.TyAbo_IdAbo)
                .ForeignKey("dbo.Clients", t => t.Client_IdClient)
                .Index(t => t.TyAbo_IdAbo)
                .Index(t => t.Client_IdClient);
            
            CreateTable(
                "dbo.Meubles",
                c => new
                    {
                        IdMeuble = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Category = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        Prix = c.Double(nullable: false),
                        Livraison = c.Int(nullable: false),
                        Etat = c.Int(nullable: false),
                        Disponibilite = c.Int(nullable: false),
                        Client_IdClient = c.Int(),
                    })
                .PrimaryKey(t => t.IdMeuble)
                .ForeignKey("dbo.Clients", t => t.Client_IdClient)
                .Index(t => t.Client_IdClient);
            
            CreateTable(
                "dbo.TyAboes",
                c => new
                    {
                        IdAbo = c.Int(nullable: false, identity: true),
                        Prix = c.Single(nullable: false),
                        Libelle = c.String(),
                        TypeAbo = c.String(),
                        Description = c.String(),
                        Dure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAbo);
            
            AddColumn("dbo.Clients", "Prenom", c => c.String());
            AddColumn("dbo.Clients", "Tel", c => c.String());
            AddColumn("dbo.Clients", "Mail", c => c.String());
            AddColumn("dbo.Clients", "TyAbo_IdAbo", c => c.Int());
            CreateIndex("dbo.Clients", "TyAbo_IdAbo");
            AddForeignKey("dbo.Clients", "TyAbo_IdAbo", "dbo.TyAboes", "IdAbo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Abonnements", "Client_IdClient", "dbo.Clients");
            DropForeignKey("dbo.Clients", "TyAbo_IdAbo", "dbo.TyAboes");
            DropForeignKey("dbo.Abonnements", "TyAbo_IdAbo", "dbo.TyAboes");
            DropForeignKey("dbo.Meubles", "Client_IdClient", "dbo.Clients");
            DropIndex("dbo.Meubles", new[] { "Client_IdClient" });
            DropIndex("dbo.Clients", new[] { "TyAbo_IdAbo" });
            DropIndex("dbo.Abonnements", new[] { "Client_IdClient" });
            DropIndex("dbo.Abonnements", new[] { "TyAbo_IdAbo" });
            DropColumn("dbo.Clients", "TyAbo_IdAbo");
            DropColumn("dbo.Clients", "Mail");
            DropColumn("dbo.Clients", "Tel");
            DropColumn("dbo.Clients", "Prenom");
            DropTable("dbo.TyAboes");
            DropTable("dbo.Meubles");
            DropTable("dbo.Abonnements");
        }
    }
}
