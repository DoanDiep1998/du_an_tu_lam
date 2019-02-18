using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class Business
        //bảng chứa tên nghiệp vụ ứng dụng: Tên controller

    {
        [Key]
        public string BusinessId { get; set; }
        public string BusinessName { get; set; }
        public virtual ICollection<Permisstion_Group> Permisstion_Groups { get; set; }
    }
}
