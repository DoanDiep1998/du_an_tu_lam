using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
  public   class Bill
    {
        [Key]
        public string BillId { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [Display(Name = "Tổng tiền")]
        public float TotalMoney { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Ghi chú")]
        public string Comment { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        [ForeignKey("Payment")]
        public string PaymentId { get; set; }
        [ForeignKey("Transportation")]
        public string TransportationId { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        //Navigate
        public ICollection<BillDetail>BillDetails { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Transportation Transportation { get; set; }


    }
}
