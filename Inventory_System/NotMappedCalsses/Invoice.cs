using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.NotMappedCalsses
{
    class Invoice
    {
        public DateTime date{ get; set; }
        public string Customer { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public double PriceForPiece { get; set; }

        
    }
}
