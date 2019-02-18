using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
   public class Category
    {
        [Key]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Tên danh mục cha")]
        public string CategoryName { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        public ICollection<CategoryDetail> CategoryDetails { get; set; }
    }
}
