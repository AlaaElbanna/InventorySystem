using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.NotMappedCalsses
{
    [NotMapped]
    public class GetTransaction
    {
        public string Date { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string TotalPrice { get; set; }
        public string Transaction { get; set; }
    }
}
