using Data.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
  public  class MenShopDbContext:DbContext
    {
        public MenShopDbContext() : base("MenShopContext")
        {

        }
        public DbSet<Banner> banners { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<BillDetail> billDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetail> CategoryDetails { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<FeedBack> feedBacks { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Transportation> transportations { get; set; }

        public DbSet<User> users { get; set; }
        public DbSet<Business> businesses { get; set; }
        public DbSet<Permisstion> permisstions { get; set; }
        public DbSet<Permisstion_Group> Permisstion_Groups { get; set; }
    }
}
