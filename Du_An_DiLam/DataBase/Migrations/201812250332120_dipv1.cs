namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dipv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        BannerId = c.String(nullable: false, maxLength: 128),
                        BannerName = c.String(),
                        Picture = c.String(),
                        Link = c.String(),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BannerId);
            
            CreateTable(
                "dbo.BillDetails",
                c => new
                    {
                        BillDetailId = c.String(nullable: false, maxLength: 128),
                        BillId = c.String(maxLength: 128),
                        ProductId = c.String(maxLength: 128),
                        Total = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.BillDetailId)
                .ForeignKey("dbo.Bills", t => t.BillId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.BillId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(maxLength: 128),
                        TotalMoney = c.Single(nullable: false),
                        CustomerName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Comment = c.String(),
                        Status = c.Boolean(nullable: false),
                        PaymentId = c.String(maxLength: 128),
                        TransportationId = c.String(maxLength: 128),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Payments", t => t.PaymentId)
                .ForeignKey("dbo.Transportations", t => t.TransportationId)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymentId)
                .Index(t => t.TransportationId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        CustomerName = c.String(),
                        Email = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        User = c.String(),
                        Password = c.String(),
                        Avatar = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        FeedBackId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.String(maxLength: 128),
                        CustomerId = c.String(maxLength: 128),
                        Star = c.Int(nullable: false),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FeedBackId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 128),
                        ProductName = c.String(),
                        CategoryDetailId = c.String(maxLength: 128),
                        SupplierId = c.String(maxLength: 128),
                        Picture = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        PriceSale = c.Single(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Show = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.CategoryDetails", t => t.CategoryDetailId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.CategoryDetailId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.CategoryDetails",
                c => new
                    {
                        CategoryDetailId = c.String(nullable: false, maxLength: 128),
                        CategoryId = c.String(maxLength: 128),
                        CategoryDetailName = c.String(),
                        Show = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryDetailId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.String(nullable: false, maxLength: 128),
                        CategoryName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.String(nullable: false, maxLength: 128),
                        SupplierName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Show = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.String(nullable: false, maxLength: 128),
                        PaymentName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Show = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.Transportations",
                c => new
                    {
                        TransportationId = c.String(nullable: false, maxLength: 128),
                        TransportationName = c.String(),
                        CraeteDate = c.DateTime(nullable: false),
                        Show = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TransportationId);
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        BusinessId = c.String(nullable: false, maxLength: 128),
                        BusinessName = c.String(),
                    })
                .PrimaryKey(t => t.BusinessId);
            
            CreateTable(
                "dbo.Permisstion_Group",
                c => new
                    {
                        Permisstion_GroupId = c.String(nullable: false, maxLength: 128),
                        PermistionName = c.String(),
                        BusinessId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Permisstion_GroupId)
                .ForeignKey("dbo.Businesses", t => t.BusinessId)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Permisstions",
                c => new
                    {
                        PermisstionId = c.String(nullable: false, maxLength: 128),
                        Permisstion_GroupId = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PermisstionId)
                .ForeignKey("dbo.Permisstion_Group", t => t.Permisstion_GroupId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.Permisstion_GroupId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        Avatar = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Allowed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permisstions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Permisstions", "Permisstion_GroupId", "dbo.Permisstion_Group");
            DropForeignKey("dbo.Permisstion_Group", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.BillDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BillDetails", "BillId", "dbo.Bills");
            DropForeignKey("dbo.Bills", "TransportationId", "dbo.Transportations");
            DropForeignKey("dbo.Bills", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Bills", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.FeedBacks", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.FeedBacks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CategoryDetailId", "dbo.CategoryDetails");
            DropForeignKey("dbo.CategoryDetails", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Permisstions", new[] { "UserId" });
            DropIndex("dbo.Permisstions", new[] { "Permisstion_GroupId" });
            DropIndex("dbo.Permisstion_Group", new[] { "BusinessId" });
            DropIndex("dbo.CategoryDetails", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryDetailId" });
            DropIndex("dbo.FeedBacks", new[] { "CustomerId" });
            DropIndex("dbo.FeedBacks", new[] { "ProductId" });
            DropIndex("dbo.Bills", new[] { "TransportationId" });
            DropIndex("dbo.Bills", new[] { "PaymentId" });
            DropIndex("dbo.Bills", new[] { "CustomerId" });
            DropIndex("dbo.BillDetails", new[] { "ProductId" });
            DropIndex("dbo.BillDetails", new[] { "BillId" });
            DropTable("dbo.Users");
            DropTable("dbo.Permisstions");
            DropTable("dbo.Permisstion_Group");
            DropTable("dbo.Businesses");
            DropTable("dbo.Transportations");
            DropTable("dbo.Payments");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            DropTable("dbo.CategoryDetails");
            DropTable("dbo.Products");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.Customers");
            DropTable("dbo.Bills");
            DropTable("dbo.BillDetails");
            DropTable("dbo.Banners");
        }
    }
}
