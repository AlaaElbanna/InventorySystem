using Final;
using Inventory_System.Adding;
using Inventory_System.Returnable;
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
    /// Interaction logic for PurchaseInvoice.xaml
    /// </summary>
    public partial class PurchaseInvoice : Window
    {
        public PurchaseInvoice()
        {
            InitializeComponent();
        }

        private void CreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            AddItem rec = new AddItem();
            rec.Show();
            this.Close();

        }

        private void AddItemToExistInvoice_Click(object sender, RoutedEventArgs e)
        {
            AddToPurchaseInvoice rec = new AddToPurchaseInvoice();
            rec.Show();
            this.Close();
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Billls rec = new Billls();
            rec.Show();
            this.Close();

        }

        private void ReturnToSupplier_Click(object sender, RoutedEventArgs e)
        {
            BackFromSupplier back = new BackFromSupplier();
            back.Show();
            this.Close();

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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
