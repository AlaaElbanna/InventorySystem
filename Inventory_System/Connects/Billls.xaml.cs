using Final;
using Inventory_System.Adding;
using Inventory_System.Bills;
using Inventory_System.EF_Classes;
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

namespace Inventory_System.Connects
{
    /// <summary>
    /// Interaction logic for Bills.xaml
    /// </summary>
    public partial class Billls : Window
    {
        public Billls()
        {
            InitializeComponent();
        }

        private void ReceiptInvoice_Click(object sender, RoutedEventArgs e)
        {
            ReceiptInvoices rec = new ReceiptInvoices();
            rec.Show();
            this.Close();
        }

        private void PurchaseInvoice_Click(object sender, RoutedEventArgs e)
        {
            PurchaseInvoice rec = new PurchaseInvoice();
            rec.Show();
            this.Close();

        }

        private void SellInvoice_Click(object sender, RoutedEventArgs e)
        {

            SellInvoicess rec = new SellInvoicess();
            rec.Show();
            this.Close();

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
          
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
