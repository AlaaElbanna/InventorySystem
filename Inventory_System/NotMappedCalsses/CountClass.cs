using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.NotMappedCalsses
{
    [NotMapped]
    public class CountClass
    {
        public int ID { get; set; }
        public int Count { get; set; }
    }
}
