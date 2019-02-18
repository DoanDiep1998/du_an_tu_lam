using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
   public class Transportation
    {
        [Key]
        public string TransportationId { get; set; }
        public string TransportationName { get; set; }
        public DateTime CraeteDate { get; set; }
        public bool Show { get; set; }
    }
}
