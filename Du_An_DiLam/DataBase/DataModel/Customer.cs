using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
  public   class Customer
    {
        [Key]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [EmailAddress(ErrorMessage = "sai định dạng email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Giới tính")]
        public bool Gender { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Sinh nhật")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        //[StringLength(11, MinimumLength = 10, ErrorMessage = "số điện thoại là 10 hoặc 11 số")]
        [Display(Name = "Số điện thoại")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Tài khoản")]
        public string User { get; set; }      
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        public  ICollection<Bill> Bills { get; set; }
        public  ICollection<FeedBack> FeedBacks { get; set; }

    }
}
