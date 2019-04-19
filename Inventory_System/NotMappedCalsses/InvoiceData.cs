using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.NotMappedCalsses
{
    [NotMapped]
    class InvoiceData
    {
        public Dictionary<bool, string> KindOfInvoice = new Dictionary<bool, string>()
        {
           {  true,"Sell" },
           {  false,"Mortag3" }
       
        };
        public Dictionary<bool, string> KindOfPay = new Dictionary<bool, string>()
       {
           {  true,"Fawry" },
           {  false,"Agl" },
          
        };
    }
}
