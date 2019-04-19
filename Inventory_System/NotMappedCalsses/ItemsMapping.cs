using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System
{
    [NotMapped]
    public class ItemsMapping
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public string SalesMan { get; set; }
        public double BuyPrice { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
