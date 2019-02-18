using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    // phân quyền 
    //(1 người có nhiều quyền. 1 quyền có nhiều người)

     public class Permisstion
    {
        public string PermisstionId { get; set; }
        [ForeignKey("Permisstion_Group")]
        public string Permisstion_GroupId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }//Usẻr
        public virtual Permisstion_Group Permisstion_Group { get; set; }//action
    }
}
