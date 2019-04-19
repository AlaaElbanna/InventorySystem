using Inventory_System.EF_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.DataBaseLayers
{
    class PurchaseInvoiceLayer : Base
    {
        public purchaseInvoice ReturnInvoice(int id, DateTime date, bool InvoiceValue)
        {
            var query = context.purchaseInvoices.Where(t => t.Supplier_Id == id && t.Date == date && t.KindOfInvoice == InvoiceValue).FirstOrDefault();
            return query;
        }
        public IQueryable<purchaseInvoice> ReturnAllInvoice()
        {
            return context.purchaseInvoices;

        }

        public IQueryable<purchaseInvoice> ReturnInvoiceBySupplier(int id)
        {
            return context.purchaseInvoices.Where(c => c.Supplier_Id == id);

        }
        public IQueryable<ItemsMapping> ReturnAllInvoiceWithItemsMapping (int pur_id)
        {
            var Items = from p in context.ItemInPurchaseInvoices
                        from inv in context.purchaseInvoices
                        from t in context.Items
                        from cus in context.Suppliers
                        where p.purchaseInvoice_Id == pur_id && p.Item_Id == t.ID && inv.Supplier_Id == cus.ID && p.purchaseInvoice_Id == inv.ID
                        select new ItemsMapping
                        {
                            Name = t.name,
                            SalesMan = cus.Name,
                            Quantity = p.Quantity,
                            BuyPrice = t.BuyPrice,
                            TotalPrice = p.Quantity * t.BuyPrice,
                            Date = inv.Date
                        };
            return Items;
        }
    }
}