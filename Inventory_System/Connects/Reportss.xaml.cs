using Final;
using Inventory_System.Adding;
using Inventory_System.Bills;
using Inventory_System.EF_Classes;
using Inventory_System.Reports;
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
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reportss : Window
    {
        public Reportss()
        {
            InitializeComponent();
        }

        private void AllItems_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nw = new MainWindow();
            nw.Show();
            this.Close();

        }

        private void ShowSelledItems_Click(object sender, RoutedEventArgs e)
        {
            SalesItem sl = new SalesItem();
            sl.Show();
            this.Close();

        }

        private void ShowStayedItems_Click(object sender, RoutedEventArgs e)
        {
            ItemForLongTime lng = new ItemForLongTime();
            lng.Show();
            this.Close();

        }

        private void ShowBackedItems_Click(object sender, RoutedEventArgs e)
        {
            returnableItem ret = new returnableItem();
            ret.Show();
            this.Close();
        }

        private void ShowITemsLessThanANumber_Click(object sender, RoutedEventArgs e)
        {
            LessQuantity lss = new LessQuantity();
            lss.Show();
            this.Close();
        }

        private void ItemsTransaction_Click(object sender, RoutedEventArgs e)
        {
            ItemTranscations tran = new ItemTranscations();
            tran.Show();
            this.Close();
        }

        private void BackToSellItemPercent_Click(object sender, RoutedEventArgs e)
        {
            BacKToSellPercent bck = new BacKToSellPercent();
            bck.Show();
            this.Close();
        }

        private void ShowReciptInvoiceDetails_Click(object sender, RoutedEventArgs e)
        {
            ShowRecieptInvoice sr = new ShowRecieptInvoice();
            sr.Show();
            this.Close();
        }

        private void ShowSellInvoiceDetails_Click(object sender, RoutedEventArgs e)
        {
            ShowInvoice sr = new ShowInvoice();
            sr.Show();
            this.Close();

        }

        private void ShowPurchaseInvoiceDetails_Click(object sender, RoutedEventArgs e)
        {
            ShowPurchaseInvoice sr = new ShowPurchaseInvoice();
            sr.Show();
            this.Close();
        }

        private void ShowLatePaymentForSalesMan_Click(object sender, RoutedEventArgs e)
        {
            SaleMenAndLatePayment s = new SaleMenAndLatePayment();
            s.Show();
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
