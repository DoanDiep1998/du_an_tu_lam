using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{ 
    public class FeedBack
    {
        [Key]
        public string FeedBackId { get; set; }
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [Display(Name = "Sao")]
        public int Star { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Ngày ")]
        public DateTime CreateDate { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
