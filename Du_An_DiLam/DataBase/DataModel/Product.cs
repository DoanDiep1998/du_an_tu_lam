using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
        [ForeignKey("CategoryDetail")]
        public string CategoryDetailId { get; set; }
        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Ảnh chính  sản phẩm")]
        public string PictureShow { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Ảnh  sản phẩm")]
        public string Picture { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Mô tả ")]
        public string Description { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Giá")]
        public float Price { get; set; }
        [Required(ErrorMessage = "chưa nhập")]
        [Display(Name = "Giá khuyến mãi")]
        public float PriceSale { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Show { get; set; }
        //NAVIGATE
        public virtual CategoryDetail CategoryDetail { get; set; }
        public virtual Supplier Supplier { get; set; }
        public  ICollection<FeedBack> FeedBacks { get; set; }
        public  ICollection<BillDetail> BillDetails { get; set; }


    }
}
