using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class BillDetail
    {
        public string BillDetailId { get; set; }
        public string BillId { get; set; }
        public string ProductId { get; set; }
        public int Total { get; set; }
        public float Price { get; set; }

    }
}
