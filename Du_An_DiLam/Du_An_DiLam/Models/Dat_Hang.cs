using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Du_An_DiLam.Models
{
    public class Dat_Hang
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Payment { get; set; }
        public string Transport  { get; set; }
        public string Comment { get; set; }
        public float TotalMoney { get; set; }
        public List<ProductOrder> products { get; set; }
    }
}