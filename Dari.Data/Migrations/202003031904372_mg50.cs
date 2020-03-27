namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg50 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Annonces", "TypeAn", c => c.Int(nullable: false));
            DropColumn("dbo.Annonces", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Annonces", "Type", c => c.String());
            DropColumn("dbo.Annonces", "TypeAn");
        }
    }
}
