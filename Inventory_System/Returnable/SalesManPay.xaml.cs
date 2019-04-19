using Final;
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
    /// Interaction logic for SalesManPay.xaml
    /// </summary>
    public partial class SalesManPay : Window
    {
        Context context;
        double TotalValues = 0, Current = 0;
        public SalesManPay()
        {
            context = new Context();
            InitializeComponent();
            var query2 = context.salesmans;
            SalesManCombo.SelectedValuePath = "ID";
            SalesManCombo.DisplayMemberPath = "Name";
            SalesManCombo.ItemsSource = query2.ToList();


        }
        public void CompleteData()
        {
            ListView.Items.Clear();
            int sal_Id = int.Parse(SalesManCombo.SelectedValue.ToString());
            var query = context.SalesInvoices.Where(s => s.salesman_Id == sal_Id && s.KindOfInvoice == true && s.TypeOfPay == false);
            NoInvoice.SelectedValuePath = "ID";
            NoInvoice.DisplayMemberPath = "ID";
            NoInvoice.ItemsSource = query.ToList();


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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are You Sure Want to Pay? ", "Suring", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int inv_Id = int.Parse(NoInvoice.SelectedValue.ToString());
                Total_Current.Text = Total.Text;
                Total.Text = "";
                var query = context.SalesInvoices.Where(i => i.ID == inv_Id).FirstOrDefault();
                query.TypeOfPay = true;
                foreach (var item in ListView.Items)
                {
                    ListView_Copy.Items.Add(item);
                }
                ListView.Items.Clear();
                context.SaveChanges();
            }

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SalesManCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TotalValues = 0;
            Current = 0;
            Total.Text = "";
            Total_Current.Text = "";
            ListView_Copy.Items.Clear();
            CompleteData();



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are You Sure You Want To Get It Back", "Back", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int inv_Id = int.Parse(NoInvoice.SelectedValue.ToString());
                Total.Text = Total_Current.Text;
                Total_Current.Text = "";
                var query = context.SalesInvoices.Where(i => i.ID == inv_Id).FirstOrDefault();
                query.TypeOfPay = false;
                foreach (var item in ListView_Copy.Items)
                {
                    ListView.Items.Add(item);
                }
                ListView_Copy.Items.Clear();
                context.SaveChanges();
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void NoInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView.Items.Clear();
            TotalValues = 0;
            if (NoInvoice.SelectedValue == null)
                return;
            int NoOFInvoice = int.Parse(NoInvoice.SelectedValue.ToString());
            int sal_Id = int.Parse(SalesManCombo.SelectedValue.ToString());

            var query2 = from si in context.SalesInvoices
                         from ts in context.ItemInSalesInvoices
                         from item in context.Items
                         from customer in context.Customers

                         where ts.SalesInvoice_Id == NoOFInvoice &&
                         si.TypeOfPay == false &&
                         si.KindOfInvoice == true
                         && si.salesman_Id == sal_Id &&
                         si.ID == ts.SalesInvoice_Id &&
                         ts.Item_Id == item.ID &&
                         si.Customer_Id == customer.ID
                         select new Invoice
                         {
                             date = si.Date,
                             Customer = customer.Name,
                             Item = item.name,
                             Quantity = ts.Quantity,
                             PriceForPiece = item.BuyPrice
                         };


            foreach (var item in query2)
            {
                Invoice g = item as Invoice;
                TotalValues += (g.PriceForPiece * g.Quantity);
                Total.Text = TotalValues.ToString();
                ListView.Items.Add(g);
            }
        }


    }
}
