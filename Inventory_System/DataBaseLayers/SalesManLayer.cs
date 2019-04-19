using Inventory_System.EF_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.DataBaseLayers
{
    public class SalesManLayer : Base
    {
     
        public IQueryable<salesman> GetAllSalesMan()
        {
            var sales = context.salesmans;
            return sales;
        }
        public salesman GetSalesManById(int id)
        {
            var sales = context.salesmans.Where(ite => ite.ID == id).FirstOrDefault();
            return sales;
        }
        public void AddReciptToSales(salesman sales, ReceiptInvoice itemsRecipted)
        {
            sales.ReceiptInvoices.Add(itemsRecipted);

        }

    }
}
