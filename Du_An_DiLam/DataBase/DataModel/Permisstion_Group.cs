using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{// Action 
 public  class Permisstion_Group
    {
        [Key]
        public string Permisstion_GroupId { get; set; }
        public string PermistionName { get; set; }
        public string Depscription { get; set; }
        [ForeignKey("Business")]
        public string BusinessId { get; set; }
        public virtual Business Business { get; set; }
        public virtual ICollection<Permisstion> Permisstions { get; set; }

    }
}
