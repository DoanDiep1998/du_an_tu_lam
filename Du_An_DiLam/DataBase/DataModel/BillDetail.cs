using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class BillDetail
    {
        [Key]
        public string BillDetailId { get; set; }
        [ForeignKey("Bill")]
        public string BillId { get; set; }
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public int Total { get; set; }
        public float Price { get; set; }
        public  virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }

    }
}
