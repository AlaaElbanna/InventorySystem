using Inventory_System.EF_Classes;
using Inventory_System.NotMappedCalsses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.DataBaseLayers
{
    public class ItemLayer : Base
    {
        enum TypeTrans
        {
            Sell_to_Customer, Return_from_SaleMan, Reciept_to_SaleMan,
            Purchase_from_Supplier, Return_to_Supplier
        };

        public List<GetstagnantItem> getItemForLongTime()
        {
            List<int> id = context.ItemInSalesInvoices.Select(s => s.Item_Id).ToList();
            List<int> id2 = context.ItemInReceiptInvoices.Select(s => s.Item_Id).ToList();
            var query2 = context.Items.Where(item => !id.Contains(item.ID) && !id2.Contains(item.ID)).Select(i =>
                new
                {
                    Code = i.ID,
                    Name = i.name,
                    Category = context.Catogerys.Where(cat => cat.ID == i.Cat_Id).Select(cat => cat.Name).FirstOrDefault(),
                    Quatity = i.Quantity,
                    Date = context.purchaseInvoices.Where(ip => ip.ID ==
                    context.ItemInPurchaseInvoices.Where(p => p.Item_Id == i.ID)
                    .Select(p => p.purchaseInvoice_Id)
                     .FirstOrDefault()).Select(ip => ip.Date).FirstOrDefault()

                }).ToList();
            List<GetstagnantItem> list = new List<GetstagnantItem>();
            foreach (var item in query2)
            {
                if ((DateTime.Now.Month - item.Date.Month) >= 1)
                {
                    list.Add(
                        new GetstagnantItem
                        {
                            Code = item.Code.ToString(),
                            Name = item.Name,
                            Category = item.Category,
                            Quatity = item.Quatity.ToString()
                        }

                        );
                }
            }
            return list;

        }

        public List<GetTransaction> GetTransactionItems()
        {
            List<GetTransaction> list = new List<GetTransaction>();
            //////////////////////////////////////////////////////////////////////
            var query = (from sale in context.SalesInvoices
                         from qitem in context.ItemInSalesInvoices
                         where qitem.SalesInvoice_Id == sale.ID
                         && sale.KindOfInvoice == true
                         select new
                         {
                             Date = sale.Date,

                             Item = (from item in context.Items
                                     where item.ID == qitem.Item_Id
                                     select new { name = item.name, buy = item.SellPrice }).FirstOrDefault(),

                             Quantity = qitem.Quantity,

                         }
                         ).ToList();
            if (query != null)
            {
                foreach (var sale in query)
                {
                    list.Add(
                        new GetTransaction
                        {
                            Date = sale.Date.Date.ToString(),
                            Item = sale.Item.name,
                            Quantity = sale.Quantity.ToString(),
                            Price = sale.Item.buy.ToString(),
                            TotalPrice = (sale.Item.buy * sale.Quantity).ToString(),
                            Transaction = TypeTrans.Sell_to_Customer.ToString()

                        }
                        );
                }

            }
            ////////////////////////////////////////////////////////////
            var query2 = (from sale in context.SalesInvoices
                          from qitem in context.ItemInSalesInvoices
                          where qitem.SalesInvoice_Id == sale.ID
                          && sale.KindOfInvoice == false
                          select new
                          {
                              Date = sale.Date,

                              Item = (from item in context.Items
                                      where item.ID == qitem.Item_Id
                                      select new { name = item.name, buy = item.SellPrice }).FirstOrDefault(),

                              Quantity = qitem.Quantity,

                          }
                       ).ToList();

            if (query2 != null)
            {
                foreach (var sale in query2)
                {
                    list.Add(
                        new GetTransaction
                        {
                            Date = sale.Date.Date.ToString(),
                            Item = sale.Item.name,
                            Quantity = sale.Quantity.ToString(),
                            Price = sale.Item.buy.ToString(),
                            TotalPrice = (sale.Item.buy * sale.Quantity).ToString(),
                            Transaction = TypeTrans.Return_from_SaleMan.ToString()

                        }
                        );
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////
            var query3 = (from recipet in context.ReceiptInvoices
                          from qitem in context.ItemInReceiptInvoices
                          where qitem.ReceiptInvoice_Id == recipet.ID
                          select new
                          {
                              Date = recipet.Date,

                              Item = (from item in context.Items
                                      where item.ID == qitem.Item_Id
                                      select new { name = item.name, buy = item.SellPrice }).FirstOrDefault(),

                              Quantity = qitem.Quantity,

                          }
                      ).ToList();

            if (query3 != null)
            {
                foreach (var sale in query3)
                {
                    list.Add(
                        new GetTransaction
                        {
                            Date = sale.Date.Date.ToString(),
                            Item = sale.Item.name,
                            Quantity = sale.Quantity.ToString(),
                            Price = sale.Item.buy.ToString(),
                            TotalPrice = (sale.Item.buy * sale.Quantity).ToString(),
                            Transaction = TypeTrans.Reciept_to_SaleMan.ToString()

                        }
                        );
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////
            var query4 = (from purchase in context.purchaseInvoices
                          from qitem in context.ItemInPurchaseInvoices
                          where qitem.purchaseInvoice_Id == purchase.ID
                          && purchase.KindOfInvoice == true
                          select new
                          {
                              Date = purchase.Date,

                              Item = (from item in context.Items
                                      where item.ID == qitem.Item_Id
                                      select new { name = item.name, buy = item.BuyPrice }).FirstOrDefault(),

                              Quantity = qitem.Quantity,

                          }
                      ).ToList();
            if (query4 != null)
            {
                foreach (var sale in query4)
                {
                    list.Add(
                        new GetTransaction
                        {
                            Date = sale.Date.Date.ToString(),
                            Item = sale.Item.name,
                            Quantity = sale.Quantity.ToString(),
                            Price = sale.Item.buy.ToString(),
                            TotalPrice = (sale.Item.buy * sale.Quantity).ToString(),
                            Transaction = TypeTrans.Purchase_from_Supplier.ToString()

                        }
                        );
                }

            }
            ////////////////////////////////////////////////////////////////////////////////////////
            var query5 = (from purchase in context.purchaseInvoices
                          from qitem in context.ItemInPurchaseInvoices
                          where qitem.purchaseInvoice_Id == purchase.ID

                          && purchase.KindOfInvoice == false
                          select new
                          {
                              Date = purchase.Date,

                              Item = (from item in context.Items
                                      where item.ID == qitem.Item_Id
                                      select new { name = item.name, buy = item.BuyPrice }).FirstOrDefault(),

                              Quantity = qitem.Quantity,

                          }
                    ).ToList();

            if (query5 != null)
            {
                foreach (var sale in query5)
                {
                    list.Add(
                        new GetTransaction
                        {
                            Date = sale.Date.Date.ToString(),
                            Item = sale.Item.name,
                            Quantity = sale.Quantity.ToString(),
                            Price = sale.Item.buy.ToString(),
                            TotalPrice = (sale.Item.buy * sale.Quantity).ToString(),
                            Transaction = TypeTrans.Return_to_Supplier.ToString()

                        });
                }
            }
            return list;
        }


        public List<ReturnData> ReturnableItems()
        {
            var query = (from sale in context.SalesInvoices
                         from isale in context.ItemInSalesInvoices
                         where sale.KindOfInvoice == false
                         && sale.ID == isale.SalesInvoice_Id
                         select new
                         {
                             Item = (from item in context.Items
                                     where item.ID == isale.Item_Id
                                     select item
                                      ).FirstOrDefault(),

                             SaleMan = context.salesmans.Where(m => m.ID == sale.salesman_Id).FirstOrDefault(),

                             Customer = context.Customers.Where(c => c.ID == sale.Customer_Id).FirstOrDefault(),
                             Quantity = isale.Quantity,

                             Date = sale.Date,


                         }).ToList();

            List<ReturnData> list = new List<ReturnData>();
            foreach (var item in query)
            {
                list.Add(
                    new ReturnData
                    {
                        Code = item.Item.ID.ToString(),
                        ItemName = item.Item.name,
                        ReturnDate = item.Date.ToString(),
                        Quantity = item.Quantity.ToString(),
                        TotalPrice = (item.Quantity * item.Item.SellPrice).ToString(),
                        SaleMan = item.SaleMan.Name,
                        Customer = item.Customer.Name
                    });

            }
            return list;
        }


        public List<GetSaleManWithSales> SaleMenAndLatePymant()
        {

            var Data = (from qitem in context.ItemInSalesInvoices
                        from sm in context.SalesInvoices
                        where sm.KindOfInvoice == true && sm.TypeOfPay == false
                               && sm.ID == qitem.SalesInvoice_Id
                        orderby sm.salesman_Id
                        select new
                        {
                            Date = (from s in context.SalesInvoices
                                    where s.ID == sm.ID
                                    orderby s.Date descending
                                    select s).FirstOrDefault(),

                            Quantity = qitem.Quantity,

                            SaleMan = (from SMan in context.salesmans
                                       where sm.salesman_Id == SMan.ID
                                       select SMan.Name
                                      ).FirstOrDefault(),

                            Item = (from item in context.Items
                                    where item.ID == qitem.Item_Id
                                    select item
                                   ).FirstOrDefault(),




                        }).ToList();
            List<GetSaleManWithSales> list = new List<GetSaleManWithSales>();
            foreach (var item in Data)
            {
                list.Add(
                    new GetSaleManWithSales
                    {
                        SaleManName = item.SaleMan,
                        LastDate = item.Date.Date.ToString(),
                        Item = item.Item.name,
                        Qunatity = item.Quantity.ToString(),
                        TotalPrice = (item.Quantity * item.Item.SellPrice).ToString(),

                    });
            }
            return list;
        }

        public List<SaleData> SalesItem()
        {
            List<SaleData> Data = new List<SaleData>();
            var query = (from itemsale in context.ItemInSalesInvoices
                         select new
                         {
                             Item = (from item in context.Items
                                     where item.ID == itemsale.Item_Id
                                     select new { ID = item.ID, name = item.name, buy = item.SellPrice, sell = item.BuyPrice }
                                      ).FirstOrDefault(),

                             SaleMan = (from saleman in context.salesmans
                                        where saleman.ID ==
                                        (from sale in context.SalesInvoices
                                         where sale.ID == itemsale.SalesInvoice_Id
                                         select sale.salesman_Id).FirstOrDefault()
                                        select saleman.Name).FirstOrDefault(),

                             Customer = (from custoemr in context.Customers
                                         where custoemr.ID ==
                                         (from sale in context.SalesInvoices
                                          where sale.ID == itemsale.SalesInvoice_Id
                                          select sale.Customer_Id).FirstOrDefault()
                                         select custoemr.Name).FirstOrDefault(),

                             Quantity = itemsale.Quantity,

                             Date = (from sale in context.SalesInvoices
                                     where sale.ID == itemsale.SalesInvoice_Id
                                     select sale.Date).FirstOrDefault()



                         }).ToList();


            foreach (var item in query)
            {
                Data.Add
                    (new SaleData
                    {
                        Code = item.Item.ID.ToString(),
                        ItemName = item.Item.name,
                        SaleDate = item.Date.Date.ToString(),
                        Quantity = item.Quantity.ToString(),
                        TotalPrice = (item.Quantity * item.Item.buy).ToString(),
                        SaleMan = item.SaleMan,
                        Customer = item.Customer,
                        TotalSellPrice = item.Quantity * item.Item.sell

                    });



            }

            for (int j = 0; j < Data.Count; j++)
            {
                for (int i = j + 1; i < Data.Count; i++)
                {
                    {
                        if (Data.ElementAt(j).Code == Data.ElementAt(i).Code &&
                            Data.ElementAt(j).Customer == Data.ElementAt(i).Customer &&
                             Data.ElementAt(j).SaleDate == Data.ElementAt(i).SaleDate)
                        {
                            Data.ElementAt(j).Quantity = (int.Parse(Data.ElementAt(j).Quantity) + int.Parse(Data.ElementAt(i).Quantity)).ToString();
                            Data.ElementAt(j).TotalPrice = (double.Parse(Data.ElementAt(j).TotalPrice) + double.Parse(Data.ElementAt(i).TotalPrice)).ToString();
                            Data.ElementAt(j).TotalSellPrice = Data.ElementAt(j).TotalSellPrice + Data.ElementAt(i).TotalSellPrice;
                            Data.RemoveAt(i);
                        }

                    }
                }
            }
            return Data;
        }

        public List<GetItems> GetItems()
        {

            var items = (from item in context.Items
                         select new
                         {
                             item.ID,
                             item.name,
                             Cat_Name = (from cat in context.Catogerys
                                         where cat.ID == item.Cat_Id
                                         select cat.Name
                                         ).FirstOrDefault(),
                             item.SellPrice,
                             item.BuyPrice,
                             item.Quantity,
                         }).ToList();



            List<GetItems> list = new List<GetItems>();
            foreach (var item in items)
            {
                list.Add(new GetItems
                {
                    Code = item.ID.ToString(),
                    Name = item.name,
                    Category = item.Cat_Name,
                    SellPrice = item.SellPrice.ToString(),
                    BuyPrice = item.BuyPrice.ToString(),
                    Quantity = item.Quantity.ToString()
                });

            }
            return list;
        }

        public void SaveItem(GetItems data, int CatID)
        {
            Item item = GetItem(int.Parse(data.Code));
            item.name = data.Name;
            item.Quantity = int.Parse(data.Quantity);
            item.BuyPrice = double.Parse(data.BuyPrice);
            item.SellPrice = double.Parse(data.SellPrice);
            item.Cat_Id = CatID;
            context.SaveChanges();
        }

        public Item GetItem(int id)
        {
            Item item = context.Items.Where(i => i.ID == id).FirstOrDefault();
            return item;
        }

        public int getIDCat(int id)
        {
            return context.Items.Where(i => i.ID == id).Select(C => C.Cat_Id).FirstOrDefault();
        }

        public List<Catogery> GetCat()
        {
            return context.Catogerys.ToList();

        }

        public IQueryable<Item> GetAllItems()
        {
            var items = context.Items;
            return items;
        }

        public void AddReciptToItem(Item SelectItem, ItemInReceiptInvoice recipt)
        {
            SelectItem.ItemInReceiptInvoices.Add(recipt);

        }

        public IQueryable<ItemsMapping> GetItemWithItemsMapping(int inv_Id, DateTime date)
        {
            var Items = from p in context.ItemInPurchaseInvoices
                        from inv in context.purchaseInvoices
                        from t in context.Items
                        where p.purchaseInvoice_Id == inv_Id && p.Item_Id == t.ID && inv.Date == date && p.purchaseInvoice_Id == inv.ID
                        select new ItemsMapping
                        {
                            Name = t.name,
                            Quantity = p.Quantity,
                            BuyPrice = t.BuyPrice,
                            TotalPrice = p.Quantity * t.BuyPrice,
                            Date = inv.Date
                        };
            return Items;
        }
        public void IncreaseQuantity(Item item, int quan)
        {
            item.Quantity += quan;
            context.SaveChanges();

        }
        public void DecreaseQuantity(Item item, int quan)
        {
            item.Quantity -= quan;
            context.SaveChanges();

        }
        public IQueryable<ItemsMapping> GetRecItemWithItemsMapping(int inv_Id, DateTime date)
        {
            var Items = from p in context.ItemInReceiptInvoices
                        from inv in context.ReceiptInvoices
                        from t in context.Items
                        where p.ReceiptInvoice_Id == inv_Id && p.Item_Id == t.ID && inv.Date == date && p.ReceiptInvoice_Id == inv.ID
                        select new ItemsMapping
                        {
                            Name = t.name,
                            Quantity = p.Quantity,
                            BuyPrice = t.BuyPrice,
                            TotalPrice = p.Quantity * t.BuyPrice,
                            Date = inv.Date
                        };
            return Items;
        }
    }
}
