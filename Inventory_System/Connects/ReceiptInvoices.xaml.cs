using Inventory_System.Adding;
using Inventory_System.Bills;
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
using Inventory_System.Bills;
using Final;

namespace Inventory_System.Connects
{
    /// <summary>
    /// Interaction logic for ReceiptInvoice.xaml
    /// </summary>
    public partial class ReceiptInvoices : Window
    {
        public ReceiptInvoices()
        {
            InitializeComponent();
        }

        private void CreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            Bills.ReceiptInvoices rec = new Bills.ReceiptInvoices();
            rec.Show();
            this.Close();

        }

        

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Billls rec = new Billls();
            rec.Show();
            this.Close();

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

        private void AddItemToExistInvoice_Click_1(object sender, RoutedEventArgs e)
        {
            AddToSpecialInvoice rec = new AddToSpecialInvoice();
            rec.Show();
            this.Close();


        }
    }
}
