namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Diepv6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PictureShow", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PictureShow");
        }
    }
}
