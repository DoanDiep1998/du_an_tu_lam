using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
   public class Supplier
    {
        [Key]
        public string SupplierId { get; set; }
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Tên thương hiệu")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Trạng thái hiển thị")]
        public bool Show { get; set; }
        public ICollection<Product> Products { get; set; }
        public virtual Category Category { get; set; }
    }
}
