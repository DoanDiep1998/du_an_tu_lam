using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
  public   class Bill
    {
        [Key]
        public string BillId { get; set; }
        public string CustomerId { get; set; }
        public float TotalMoney { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public string PaymentId { get; set; }
        public string Transportation { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
