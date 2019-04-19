using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.EF_Classes
{
    public class User
    {
        public int ID { get; set; }
        public string  name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public Account account { set; get; }
    }
}
