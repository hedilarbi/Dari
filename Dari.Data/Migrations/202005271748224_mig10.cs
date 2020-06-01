namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Annonces", "price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Annonces", "price");
        }
    }
}
