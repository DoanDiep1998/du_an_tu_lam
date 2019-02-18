using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
   public class Payment
    {
        [Key]
        public string PaymentId { get; set; }
        public string PaymentName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Show { get; set; }
    }
}
