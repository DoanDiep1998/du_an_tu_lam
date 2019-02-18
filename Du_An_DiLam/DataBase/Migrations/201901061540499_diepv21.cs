namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diepv21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Banners", "BannerName", c => c.String(nullable: false));
            AlterColumn("dbo.Banners", "Picture", c => c.String(nullable: false));
            AlterColumn("dbo.Banners", "Link", c => c.String(nullable: false));
            AlterColumn("dbo.Banners", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Bills", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Bills", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Bills", "Comment", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "User", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.FeedBacks", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Picture", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.CategoryDetails", "CategoryDetailName", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "SupplierName", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "PaymentName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Avatar", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Avatar", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "FullName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Payments", "PaymentName", c => c.String());
            AlterColumn("dbo.Suppliers", "SupplierName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            AlterColumn("dbo.CategoryDetails", "CategoryDetailName", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Picture", c => c.String());
            AlterColumn("dbo.FeedBacks", "Content", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "User", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "CustomerName", c => c.String());
            AlterColumn("dbo.Bills", "Comment", c => c.String());
            AlterColumn("dbo.Bills", "Address", c => c.String());
            AlterColumn("dbo.Bills", "Email", c => c.String());
            AlterColumn("dbo.Banners", "Content", c => c.String());
            AlterColumn("dbo.Banners", "Link", c => c.String());
            AlterColumn("dbo.Banners", "Picture", c => c.String());
            AlterColumn("dbo.Banners", "BannerName", c => c.String());
        }
    }
}
