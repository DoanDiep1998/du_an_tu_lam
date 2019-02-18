using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string SupplierId { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float PriceSale { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Show { get; set; }
        

    }
}
