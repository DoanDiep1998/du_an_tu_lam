namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diepv7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "Phone");
        }
    }
}
