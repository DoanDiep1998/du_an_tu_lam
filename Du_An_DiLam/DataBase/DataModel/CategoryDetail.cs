using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
  public  class CategoryDetail
    {
        [Key]
        public string CategoryDetailId { get; set; }
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        [Display(Name = "Tên danh mục con")]
        [Required(ErrorMessage = "chưa nhập")]
        public string CategoryDetailName { get; set; }
        [Display(Name = "Trạng thái hiển thị")]
        public bool Show { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        public  virtual Category Category { get; set; }
        public  ICollection<Product> products { get; set; }
    }
}
