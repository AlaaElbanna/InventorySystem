using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.NotMappedCalsses
{
    [NotMapped]
    public class ListViewRecipt
    {
        public int ID { get; set; }
        public String Category { get; set; }
        public String Item_Name { get; set; }
        public int Quantity { get; set; }
        public double PriceForPiece { get; set; }
        public double TotalPrice { get; set; }

         }
}
