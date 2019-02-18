using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{ 
    public class FeedBack
    {
        [Key]
        public string FeedBackId { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public int Star { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
