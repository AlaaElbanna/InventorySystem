using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.NotMappedCalsses
{
    class Percent
    {
        public int ID { get; set; }
         public String Item_Name { get; set; }
        public double PriceForPiece { get; set; }

        public int SellQuantity { get; set; }
        public int BackQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public double PercentSellQuantity { get; set; }
        public double PercentBackQuantity { get; set; }
      
       
    }
}
