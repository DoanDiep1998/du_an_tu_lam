namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diepv10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permisstion_Group", "Depscription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Permisstion_Group", "Depscription");
        }
    }
}
