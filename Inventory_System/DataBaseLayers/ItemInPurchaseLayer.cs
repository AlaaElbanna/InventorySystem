using Inventory_System.EF_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.DataBaseLayers
{
    public class ItemInPurchaseLayer : Base
    {
        public ItemInPurchaseInvoice CreateInvoice(int SelectItem, int recipt, int QuantityValue)
        {
            ItemInPurchaseInvoice itemsRecipted = new ItemInPurchaseInvoice();

            itemsRecipted.Item_Id = SelectItem;
            itemsRecipted.purchaseInvoice_Id = recipt;
            itemsRecipted.Quantity = QuantityValue;

            context.ItemInPurchaseInvoices.Add(itemsRecipted);
            context.SaveChanges();
            return itemsRecipted;

        }
    }
}
