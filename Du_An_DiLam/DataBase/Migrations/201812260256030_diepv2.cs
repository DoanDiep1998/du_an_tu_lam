namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diepv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "CategoryId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Suppliers", "CategoryId");
            AddForeignKey("dbo.Suppliers", "CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Suppliers", new[] { "CategoryId" });
            DropColumn("dbo.Suppliers", "CategoryId");
        }
    }
}
