using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
  public  class User
    {
        [Key]
        public string UserId { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Mật khẩu")]
        [StringLength(32,MinimumLength =16,ErrorMessage ="mật khẩu từ 16 tớ 32 kí tự")]
        public string Password { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Giới tính")]
        public bool Gender { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Email")]
        [EmailAddress (ErrorMessage ="sai định dạng email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        //[StringLength(11,MinimumLength =10,ErrorMessage ="số điện thoại là 10 hoặc 11 số")]
        [Display(Name = "Số điện thoại")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name = "Có phải quản trị cao nhất")]
        public  bool IsAdmin { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Allowed { get; set; }
        public virtual ICollection<Permisstion> Permisstions { get; set; }
    }
}
