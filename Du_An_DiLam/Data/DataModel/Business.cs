using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class Business
    {
        [Key]
        public string BusinessId { get; set; }
        public string BusinessName { get; set; }
    }
}
