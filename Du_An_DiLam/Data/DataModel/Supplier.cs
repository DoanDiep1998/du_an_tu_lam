using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
   public class Supplier
    {
        [Key]
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Show { get; set; }
    }
}
