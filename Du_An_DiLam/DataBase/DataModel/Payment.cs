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
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Phương thức thanh toán")]
        public string PaymentName { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Show { get; set; }
    }
}
