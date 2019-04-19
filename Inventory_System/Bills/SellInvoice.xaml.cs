using Final;
using Inventory_System.Adding;
using Inventory_System.Connects;
using Inventory_System.EF_Classes;
using Inventory_System.NotMappedCalsses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inventory_System.Bills
{
    /// <summary>
    /// Interaction logic for SellInvoice.xaml
    /// </summary>
    public partial class SellInvoice : Window
    {
        Context context;
        double TotalValues = 0;
        InvoiceData invoicedata;
        SalesInvoice SellInv;

        public SellInvoice()
        {
            InitializeComponent();
            invoicedata = new InvoiceData();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
            SellInv = new SalesInvoice();
        }

        public static bool KeyByValue(Dictionary<bool, string> dict, string val)
        {
            bool key = false;
            foreach (KeyValuePair<bool, string> pair in dict)
            {
                if (pair.Value == val)
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }
        public double calculateTotal(int quantity, double price)
        {
            double CurrentValue = quantity * price;
            TotalValues += CurrentValue;
            return TotalValues;
        }
        public double SubtractTotal(int quantity, double price)
        {
            double CurrentValue = quantity * price;
            TotalValues -= CurrentValue;
            return TotalValues;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context = new Context();
            var query = context.Catogerys;
            CategoryCombo.SelectedValuePath = "ID";
            CategoryCombo.DisplayMemberPath = "Name";
            CategoryCombo.ItemsSource = query.ToList();
            var query2 = context.salesmans;
            SalesManCombo.SelectedValuePath = "ID";
            SalesManCombo.DisplayMemberPath = "Name";
            SalesManCombo.ItemsSource = query2.ToList();
            var query3 = context.Customers;
            CustomerCombo.SelectedValuePath = "ID";
            CustomerCombo.DisplayMemberPath = "Name";
            CustomerCombo.ItemsSource = query3.ToList();
            KindOfinvoice.ItemsSource = invoicedata.KindOfInvoice.Values.ToList();
            KindOfPay.ItemsSource = invoicedata.KindOfPay.Values.ToList();





        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryCombo.SelectedIndex == -1)
            {

                return;
            }
            int Cat_id = int.Parse(CategoryCombo.SelectedValue.ToString());
            var query = context.Items.Where(item => item.catogery.ID == Cat_id).ToList();
            ItemCombo.SelectedValuePath = "ID";
            ItemCombo.DisplayMemberPath = "name";
            ItemCombo.ItemsSource = query.ToList();

        }
        public ListViewSell ReturnsValues()
        {
            ListViewSell list = new ListViewSell();
            list.Category = CategoryCombo.Text;
            list.Item_Name = ItemCombo.Text;
            list.Quantity = int.Parse(Quantity.Text);
            int ID = int.Parse(ItemCombo.SelectedValue.ToString());
            list.PriceForPiece = context.Items.Where(item => item.ID == ID).Select(item => item.BuyPrice).FirstOrDefault();
            list.TotalPrice = list.Quantity * list.PriceForPiece;
            list.KindOfInvoice = KindOfinvoice.Text.ToString();
            list.KindOfPay = KindOfPay.Text.ToString();
            list.Customer = CustomerCombo.Text;
            return list;
        }
        bool CreateObject = false;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (!int.TryParse(Quantity.Text,out result))
            {
                MessageBox.Show("This Quantity is not Valid");
            }
            else if (CategoryCombo.SelectedIndex != -1 && ItemCombo.SelectedIndex != -1 && CustomerCombo.SelectedIndex != -1 && KindOfPay.SelectedIndex != -1 && KindOfinvoice.SelectedIndex != -1 && SalesManCombo.SelectedIndex != -1 && result >0)
            {
                int Cus_Id = int.Parse(CustomerCombo.SelectedValue.ToString());
                int Saller_Id = int.Parse(SalesManCombo.SelectedValue.ToString());
                var custommer = context.Customers.Where(custome => custome.ID == Cus_Id).FirstOrDefault();
                var Seller = context.salesmans.Where(saler => saler.ID == Saller_Id).FirstOrDefault();
                int Item_Id = int.Parse(ItemCombo.SelectedValue.ToString());
                var Item = context.Items.Where(it => it.ID == Item_Id).FirstOrDefault();
                ListViewSell list = ReturnsValues();
                if (CreateObject == false)
                {
                    SellInv = new SalesInvoice()
                    {
                        TotalPrice = list.TotalPrice,
                        Date = DateTime.Now,
                        KindOfInvoice = KeyByValue(invoicedata.KindOfInvoice, list.KindOfInvoice.ToString()),
                        TypeOfPay = KeyByValue(invoicedata.KindOfPay, list.KindOfPay.ToString()),
                        Customer = custommer,
                        salesman = Seller,
                        ItemInSalesInvoices = new List<ItemInSalesInvoice>()

                    };
                    CreateObject = true;
                }
                ItemInSalesInvoice salesitem = new ItemInSalesInvoice()
                {
                    Item = Item,
                    SalesInvoice = SellInv,
                    Quantity = list.Quantity,


                };
                SellInv.ItemInSalesInvoices.Add(salesitem);
                Item.ItemInSalesInvoices.Add(salesitem);
                custommer.SalesInvoices.Add(SellInv);
                Seller.SalesInvoices.Add(SellInv);
                context.SaveChanges();
                NoOfInvoice.Text = (context.SalesInvoices.Where(sal => sal.ID == SellInv.ID).Select(re => re.ID).First()).ToString();
                bool KindInvoice = KeyByValue(invoicedata.KindOfInvoice, list.KindOfInvoice.ToString());
                bool KindPay = KeyByValue(invoicedata.KindOfPay, list.KindOfPay.ToString());
                salesMan.Text = SalesManCombo.Text;
                if (KindInvoice == true && KindPay == true)
                    TotalValues += list.TotalPrice;
                Total.Text = TotalValues.ToString();
                list.ID = context.SalesInvoices.Where(inv => inv.ID == SellInv.ID).Select(se => se.ID).FirstOrDefault();
                ListView.Items.Add(list);
                Edit.IsEnabled = true;
                Delete.IsEnabled = true;
                SalesManCombo.IsEnabled = false;
                CustomerCombo.IsEnabled = false;
                KindOfinvoice.IsEnabled = false;
                KindOfPay.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("add All Data And Number Should Be Positive");
            }



        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListView.Items.Count == 0)
            {
                Edit.IsEnabled = false;
                Delete.IsEnabled = false;
                return;
            }
            else
            {
                Edit.IsEnabled = true;
                Delete.IsEnabled = true;

            }
            CategoryCombo.IsEnabled = false;
            ItemCombo.IsEnabled = false;
            SalesManCombo.IsEnabled = false;
            CustomerCombo.IsEnabled = false;
            ListViewSell Row = ListView.SelectedItem as ListViewSell;
            if (Row == null)
                return;
            CategoryCombo.Text = Row.Category;
            ItemCombo.Text = Row.Item_Name;
            Quantity.Text = Row.Quantity.ToString();
            bool KindInvoice = KeyByValue(invoicedata.KindOfInvoice, Row.KindOfInvoice.ToString());
            bool KindPay = KeyByValue(invoicedata.KindOfPay, Row.KindOfPay.ToString());

            CustomerCombo.Text = Row.Customer;
            if (KindPay == true)
                KindOfPay.Text = invoicedata.KindOfPay[true];
            else
                KindOfPay.Text = invoicedata.KindOfPay[false];

            if (KindInvoice == true)
                KindOfinvoice.Text = invoicedata.KindOfInvoice[true];
            else
                KindOfinvoice.Text = invoicedata.KindOfInvoice[false];

            NoOfInvoice.Text = (context.SalesInvoices.Where(sales => sales.ID == Row.ID).Select(re => re.ID).FirstOrDefault()).ToString();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int No = int.Parse(NoOfInvoice.Text);
            SalesInvoice CurrentEdit = context.SalesInvoices.Where(sales => sales.ID == No).FirstOrDefault();
            ItemInSalesInvoice CurrentEditQuan = context.ItemInSalesInvoices.Where(recip => recip.SalesInvoice_Id == CurrentEdit.ID).FirstOrDefault();
            if (CurrentEdit == null)
                return;
            CurrentEditQuan.Quantity = int.Parse(Quantity.Text);
            CurrentEdit.KindOfInvoice = (KindOfinvoice.Text.ToString() == invoicedata.KindOfInvoice[true]) ? true : false;
            CurrentEdit.TypeOfPay = (KindOfPay.Text.ToString() == invoicedata.KindOfPay[true]) ? true : false;
            ListViewSell Row = ListView.SelectedItem as ListViewSell;
            if (Row == null)
            {
                MessageBox.Show("Please Select row To Edit");
                return;
            }
            bool KindInvoice = KeyByValue(invoicedata.KindOfInvoice, Row.KindOfInvoice.ToString());
            bool KindPay = KeyByValue(invoicedata.KindOfPay, Row.KindOfPay.ToString());

            if ((KindInvoice == true && KindPay == true))
                SubtractTotal(Row.Quantity, Row.PriceForPiece);
            Row.Quantity = int.Parse(Quantity.Text);
            Row.Customer = CustomerCombo.Text;
            Row.TotalPrice = Row.PriceForPiece * Row.Quantity;
            Row.KindOfInvoice = invoicedata.KindOfInvoice[CurrentEdit.KindOfInvoice];
            Row.KindOfPay = invoicedata.KindOfPay[CurrentEdit.TypeOfPay];
            ListView.Items.Remove(ListView.SelectedItem);
            if (KindInvoice == true && KindPay == true)
                calculateTotal(Row.Quantity, Row.PriceForPiece);
            Total.Text = TotalValues.ToString();
            ListView.Items.Add(Row);
            context.SaveChanges();
            CategoryCombo.IsEnabled = true;
            ItemCombo.IsEnabled = true;
            CustomerCombo.IsEnabled = true;


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ListViewSell Row = ListView.SelectedItem as ListViewSell;
            if (Row == null)
            {
                MessageBox.Show("Please Select row To Remove");
                return;
            }
            bool KindInvoice = KeyByValue(invoicedata.KindOfInvoice, Row.KindOfInvoice.ToString());
            bool KindPay = KeyByValue(invoicedata.KindOfPay, Row.KindOfPay.ToString());
            if ((KindInvoice == true && KindPay == true))
                SubtractTotal(Row.Quantity, Row.PriceForPiece);
            Total.Text = TotalValues.ToString();
            ListView.Items.Remove(ListView.SelectedItem);
            var Current = context.SalesInvoices.Where(recip => recip.ID == Row.ID).First();
            var CurrentItems = context.ItemInSalesInvoices.Where(recip => recip.SalesInvoice_Id == Row.ID).FirstOrDefault();
            if (CurrentItems == null)
                return;
             context.ItemInSalesInvoices.Remove(CurrentItems);
             context.SaveChanges();
            CategoryCombo.IsEnabled = true;
            ItemCombo.IsEnabled = true;
            CustomerCombo.IsEnabled = true;


        }
        bool FirstClick = false;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (FirstClick == false)
            {
                var Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                int sal_id = int.Parse(SalesManCombo.SelectedValue.ToString());
                var sales = context.salesmans.Where(s => s.ID == sal_id).FirstOrDefault();
                var ReciptQuery = from p in context.ItemInReceiptInvoices
                                  from c in context.ReceiptInvoices
                                  where p.ReceiptInvoice_Id == c.ID && c.Date == Date && c.salesman_Id == sal_id
                                  group p by p.Item_Id into grp
                                  select new
                                  {
                                      id = grp.Key,
                                      count = grp.Sum(p => p.Quantity)
                                  };
                var SellQuery = from p in context.ItemInSalesInvoices
                                from c in context.SalesInvoices
                                where p.SalesInvoice_Id == c.ID && c.Date == Date && c.KindOfInvoice == true && c.salesman_Id == sal_id
                                group p by p.Item_Id into grp
                                select new
                                {
                                    id = grp.Key,
                                    count = grp.Sum(p => p.Quantity)
                                };
                var Mortga3Query = from p in context.ItemInSalesInvoices
                                   from c in context.SalesInvoices
                                   where p.SalesInvoice_Id == c.ID && c.Date == Date && c.KindOfInvoice == false && c.salesman_Id == sal_id
                                   group p by p.Item_Id into grp
                                   select new
                                   {
                                       id = grp.Key,
                                       count = grp.Sum(p => p.Quantity)
                                   };
                foreach (var item in ReciptQuery)
                {
                    int Mortga3 = Mortga3Query.Where(t => t.id == item.id).Select(t => t.count).FirstOrDefault();
                    int Sell = SellQuery.Where(t => t.id == item.id).Select(t => t.count).FirstOrDefault();
                    MessageBox.Show(Sell.ToString());
                    int NotSell = (item.count + Mortga3) - Sell;
                    var Currentitem = context.Items.Where(i => i.ID == item.id).FirstOrDefault();
                    if (NotSell > 0)
                        Currentitem.Quantity += NotSell;
                };
                context.SaveChanges();
                FirstClick = true;

            }
            else
            {
                MessageBox.Show("You Already Clicked It");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SalesManCombo.IsEnabled = true;
            CustomerCombo.IsEnabled = true;
            KindOfinvoice.IsEnabled = true;
            KindOfPay.IsEnabled = true;
            CreateObject = false;
            ListView.Items.Clear();
            NoOfInvoice.Text = "";


        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
