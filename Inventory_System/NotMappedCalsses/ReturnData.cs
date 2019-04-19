using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.NotMappedCalsses
{
    [NotMapped]
   public class ReturnData
    {

        public string Code { get; set; }
        public string ItemName { get; set; }
        public string ReturnDate { get; set; }
        public string Quantity { get; set; }
        public string TotalPrice { get; set; }
        public string SaleMan { get; set; }
        public string Customer { get; set; }
    }
}
