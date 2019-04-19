using Final;
using Inventory_System;
using Inventory_System.Adding;
using Inventory_System.Connects;
using Inventory_System.NotMappedCalsses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inventory_System.Returnable
{
    /// <summary>
    /// Interaction logic for BacKToSellPercent.xaml
    /// </summary>
    public partial class BacKToSellPercent : Window
    {
        Context context;
        public BacKToSellPercent()
        {
            context = new Context();
            InitializeComponent();
            var query = context.Catogerys;
            CategoreCombo.SelectedValuePath = "ID";
            CategoreCombo.DisplayMemberPath = "Name";
            CategoreCombo.ItemsSource = query.ToList();
            var query2 = context.Items;
            ItemCombo1.SelectedValuePath = "ID";
            ItemCombo1.DisplayMemberPath = "name";
            ItemCombo1.ItemsSource = query2.ToList();
            CategoreCombo.IsEnabled = false;
            ItemCombo1.IsEnabled = false;
            DatePicker.IsEnabled = false;


        }
        public IQueryable<CountClass> ReturnSell()
        {
            var SellQuery = from p in context.ItemInSalesInvoices
                            from c in context.SalesInvoices
                            where c.ID == p.SalesInvoice_Id && c.KindOfInvoice == true
                            group p by p.Item_Id into grp
                            select new CountClass
                            {
                                ID = grp.Key,
                                Count = grp.Sum(p => p.Quantity)
                            };
            return SellQuery;
        }
        public IQueryable<CountClass> ReturnMortag3()
        {
            var Mortga3Query = from p in context.ItemInSalesInvoices
                               from c in context.SalesInvoices
                               where p.SalesInvoice_Id == c.ID && c.KindOfInvoice == false
                               group p by p.Item_Id into grp
                               select new CountClass
                               {
                                   ID = grp.Key,
                                   Count = grp.Sum(p => p.Quantity)
                               };
            return Mortga3Query;

        }


        private void All1_Checked(object sender, RoutedEventArgs e)
        {
            CategoreCombo.IsEnabled = false;
            ItemCombo1.IsEnabled = false;
            DatePicker.IsEnabled = false;
            ListView.Items.Clear();
            var SellQuery = ReturnSell();
            var Mortga3Query = ReturnMortag3();
            foreach (var item in SellQuery)
            {
                int Mortga3 = Mortga3Query.Where(t => t.ID == item.ID).Select(t => t.Count).FirstOrDefault();
                var Item = context.Items.Where(t => t.ID == item.ID).FirstOrDefault();
                Percent per = new Percent()
                {
                    ID = item.ID,
                    Item_Name = Item.name,
                    PriceForPiece = Item.BuyPrice,
                    SellQuantity = item.Count,
                    BackQuantity = Mortga3,
                    TotalQuantity = Mortga3 + item.Count + Item.Quantity,
                    PercentSellQuantity = Math.Round(((item.Count) / double.Parse((Mortga3 + item.Count + Item.Quantity).ToString())) * 100, 2),
                    PercentBackQuantity = Math.Round(((Mortga3) / double.Parse((Mortga3 + item.Count + Item.Quantity).ToString())) * 100, 2)
                };
                ListView.Items.Add(per);
            }

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Category1_Checked(object sender, RoutedEventArgs e)
        {
            CategoreCombo.IsEnabled = true;
            ItemCombo1.IsEnabled = false;
            DatePicker.IsEnabled = false;


        }

        private void Item1_Checked(object sender, RoutedEventArgs e)
        {
            CategoreCombo.IsEnabled = false;
            ItemCombo1.IsEnabled = true;
            DatePicker.IsEnabled = false;

        }

        private void ByDate1_Checked(object sender, RoutedEventArgs e)
        {
            CategoreCombo.IsEnabled = false;
            ItemCombo1.IsEnabled = false;
            DatePicker.IsEnabled = true;

        }

        private void CategoreCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView.Items.Clear();
            int Cat_Id = int.Parse(CategoreCombo.SelectedValue.ToString());
            var category = context.Catogerys.Where(c => c.ID == Cat_Id).FirstOrDefault();
            var SellQuery = from p in context.ItemInSalesInvoices
                            from c in context.SalesInvoices
                            from ca in context.Catogerys
                            where p.SalesInvoice_Id == c.ID && c.KindOfInvoice == true && Cat_Id == p.Item.Cat_Id
                            group p by p.Item_Id into grp
                            select new CountClass
                            {
                                ID = grp.Key,
                                Count = grp.Sum(p => p.Quantity)
                            };
            var Mortga3Query = from p in context.ItemInSalesInvoices
                               from c in context.SalesInvoices
                               where p.SalesInvoice_Id == c.ID && c.KindOfInvoice == false && Cat_Id == p.Item.Cat_Id
                               group p by p.Item_Id into grp
                               select new CountClass
                               {
                                   ID = grp.Key,
                                   Count = grp.Sum(p => p.Quantity)
                               };
            foreach (var item in SellQuery)
            {
                int Mortga3 = Mortga3Query.Where(t => t.ID == item.ID).Select(t => t.Count).FirstOrDefault();
                var Item = context.Items.Where(t => t.ID == item.ID).FirstOrDefault();
                Percent per = new Percent()
                {
                    ID = item.ID,
                    Item_Name = Item.name,
                    PriceForPiece = Item.BuyPrice,
                    SellQuantity = item.Count,
                    BackQuantity = Mortga3,
                    TotalQuantity = Mortga3 + item.Count + Item.Quantity,
                    PercentSellQuantity = Math.Round(((item.Count) / double.Parse((Mortga3 + item.Count + Item.Quantity).ToString())) * 100, 2),
                    PercentBackQuantity = Math.Round(((Mortga3) / double.Parse((Mortga3 + item.Count + Item.Quantity).ToString())) * 100, 2)
                };
                ListView.Items.Add(per);
            }

        }

        private void ItemCombo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView.Items.Clear();
            int Item_Id = int.Parse(ItemCombo1.SelectedValue.ToString());
            var SellQuery = ReturnSell();
            var SellQuery1 = SellQuery.Where(t => t.ID == Item_Id);
            var Mortga3Query = ReturnMortag3();
            var Mortga3Query1 = Mortga3Query.Where(t => t.ID == Item_Id);
            foreach (var item in SellQuery1)
            {
                int Mortga3 = Mortga3Query1.Where(t => t.ID == item.ID).Select(t => t.Count).FirstOrDefault();
                var Item = context.Items.Where(t => t.ID == item.ID).FirstOrDefault();
                Percent per = new Percent()
                {
                    ID = item.ID,
                    Item_Name = Item.name,
                    PriceForPiece = Item.BuyPrice,
                    SellQuantity = item.Count,
                    BackQuantity = Mortga3,
                    TotalQuantity = Mortga3 + item.Count + Item.Quantity,
                    PercentSellQuantity = Math.Round(((item.Count) / double.Parse((Mortga3 + item.Count + Item.Quantity).ToString())) * 100, 2),
                    PercentBackQuantity = Math.Round(((Mortga3) / double.Parse((Mortga3 + item.Count + Item.Quantity).ToString())) * 100, 2)
                };
                ListView.Items.Add(per);
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView.Items.Clear();
            DateTime? date = DatePicker.SelectedDate;
            var SellQuery = from p in context.ItemInSalesInvoices
                            from c in context.SalesInvoices
                            from ca in context.Catogerys
                            where p.SalesInvoice_Id == c.ID && c.KindOfInvoice == true && date == c.Date
                            group p by p.Item_Id into grp
                            select new CountClass
                            {
                                ID = grp.Key,
                                Count = grp.Sum(p => p.Quantity)
                            };
            var Mortga3Query = from p in context.ItemInSalesInvoices
                               from c in context.SalesInvoices
                               where p.SalesInvoice_Id == c.ID && c.KindOfInvoice == false && date == c.Date
                               group p by p.Item_Id into grp
                               select new CountClass
                               {
                                   ID = grp.Key,
                                   Count = grp.Sum(p => p.Quantity)
                               };
            foreach (var item in SellQuery)
            {
                int Mortga3 = Mortga3Query.Where(t => t.ID == item.ID).Select(t => t.Count).FirstOrDefault();
                var Item = context.Items.Where(t => t.ID == item.ID).FirstOrDefault();

                Percent per = new Percent()
                {
                    ID = item.ID,
                    Item_Name = Item.name,
                    PriceForPiece = Item.BuyPrice,
                    SellQuantity = item.Count,
                    BackQuantity = Mortga3,
                    TotalQuantity = Mortga3 + item.Count + Item.Quantity,
                    PercentSellQuantity = Math.Round(((item.Count) / double.Parse((Mortga3 + item.Count + Item.Quantity).ToString())) * 100, 2),
                    PercentBackQuantity = Math.Round(((Mortga3) / double.Parse((Mortga3 + item.Count + Item.Quantity).ToString())) * 100, 2)
                };
                ListView.Items.Add(per);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            AddCategory add = new AddCategory();
            add.Show();
            this.Close();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem();
            add.Show();
            this.Close();

        }



        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            Billls bill = new Billls();
            bill.Show();
            this.Close();

        }

        private void Button_Click_40(object sender, RoutedEventArgs e)
        {
            AddSalesMan add = new AddSalesMan();
            add.Show();
            this.Close();

        }

        private void Button_Click_50(object sender, RoutedEventArgs e)
        {
            AddSupplier add = new AddSupplier();
            add.Show();
            this.Close();

        }

        private void Button_Click_60(object sender, RoutedEventArgs e)
        {
            Reportss report = new Reportss();
            report.Show();
            this.Close();
        }

        private void Button_Click_70(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();

        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            AddCustomer add = new AddCustomer();
            add.Show();
            this.Close();

        }
    }
}
