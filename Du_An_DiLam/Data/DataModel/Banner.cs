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
        public string BannerName { get; set; }
        public string Picture { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
