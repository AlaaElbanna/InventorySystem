using Inventory_System.EF_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.DataBaseLayers
{
    public class ItemInReceiptInvoiceLayer : Base
    {
          public ItemInReceiptInvoice CreateInvoice(int SelectItem, int recipt, int QuantityValue)
        {
            ItemInReceiptInvoice itemsRecipted = new ItemInReceiptInvoice();

            itemsRecipted.Item_Id = SelectItem;
            itemsRecipted.ReceiptInvoice_Id = recipt;
            itemsRecipted.Quantity = QuantityValue;

            context.ItemInReceiptInvoices.Add(itemsRecipted);
            context.SaveChanges();
            return itemsRecipted;
                
        }
    }
}
