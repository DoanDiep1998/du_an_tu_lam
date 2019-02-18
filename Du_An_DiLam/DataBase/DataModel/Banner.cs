using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
  public   class Banner
    {
        [Key]
        public string BannerId { get; set; }
        [Required(ErrorMessage ="chưa nhập")]
        [Display(Name ="Tên banner")]
        public string BannerName { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Ảnh")]
        public string Picture { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Đường dẫn")]
        public string Link { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
    }
}
