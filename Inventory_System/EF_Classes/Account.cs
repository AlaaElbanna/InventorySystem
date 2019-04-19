using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.EF_Classes
{
  public  class Account
    {
        [ForeignKey("user")]
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
         public User user { get; set; }
         public Boolean type { get; set; }
   
    }
}
