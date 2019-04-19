using Inventory_System.EF_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.DataBaseLayers
{
    public class ReceiptInvoiceLayer:Base
    {
        public ReceiptInvoice CreateInvoice(salesman salesman)
        {
            ReceiptInvoice recipt = new ReceiptInvoice()
            {
                Date = DateTime.Now,
                salesman = salesman,
                ItemInReceiptInvoices = new List<ItemInReceiptInvoice>()
            };
            return recipt;
        }
        public void AddInvoiceToContext(ReceiptInvoice recipt)
        {
            context.ReceiptInvoices.Add(recipt);

        }
        public void AddItemInReciptToReceipt(ReceiptInvoice recipt,ItemInReceiptInvoice itemReceipt)
        {
            recipt.ItemInReceiptInvoices.Add(itemReceipt);
        }
        public ReceiptInvoice ReturnInvoice(int id, DateTime date, bool InvoiceValue)
        {
            var query = context.ReceiptInvoices.Where(t => t.salesman_Id == id && t.Date == date).FirstOrDefault();
            return query;
        }
        public ReceiptInvoice GetInvoice(int Sal_Id,DateTime date)
        {
            return context.ReceiptInvoices.Where(t => t.salesman_Id == Sal_Id && t.Date == date).FirstOrDefault();

        }

    }

}
