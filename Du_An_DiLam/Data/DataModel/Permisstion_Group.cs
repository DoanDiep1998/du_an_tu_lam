using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
 public  class Permisstion_Group
    {
        [Key]
        public string PermisstionId { get; set; }
        public string PermistionName { get; set; }
        public string BusinessId { get; set; }

    }
}
