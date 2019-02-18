using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
  public   class Customer
    {
        [Key]
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
