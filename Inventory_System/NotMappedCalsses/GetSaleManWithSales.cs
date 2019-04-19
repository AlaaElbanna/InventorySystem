using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.NotMappedCalsses
{
    [NotMapped]
   public class GetSaleManWithSales
    {
        public string SaleManName { get; set; }
        public string LastDate { get; set; }
        public string Item { get; set; }
        public string Qunatity { get; set; }
        public string TotalPrice { get; set; }

    }
}
