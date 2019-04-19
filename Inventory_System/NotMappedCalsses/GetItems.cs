using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.NotMappedCalsses
{

    [NotMapped]
    public class GetItems
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string SellPrice { get; set; }
        public string BuyPrice { get; set; }
        public string Quantity { get; set; }
    }
}
