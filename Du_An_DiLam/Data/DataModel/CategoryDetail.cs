using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
  public  class CategoryDetail
    {
        [Key]
        public string CategoryDetailId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryDetailName { get; set; }
        public bool Show { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
