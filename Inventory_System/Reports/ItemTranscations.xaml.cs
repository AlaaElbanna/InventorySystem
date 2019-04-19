using Final;
using Inventory_System.Adding;
using Inventory_System.Connects;
using Inventory_System.DataBaseLayers;
using Inventory_System.NotMappedCalsses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

namespace Inventory_System.Reports
{
    /// <summary>
    /// Interaction logic for ItemTranscations.xaml
    /// </summary>
    public partial class ItemTranscations : Window
    {
        ItemLayer item;
        List<GetTransaction> list;

        public ItemTranscations()
        {
            InitializeComponent();
            item = new ItemLayer();
            list = item.GetTransactionItems();


        }

        private void WithDate_Checked(object sender, RoutedEventArgs e)
        {
            Picker.IsEnabled = true;


        }

        private void All_Checked(object sender, RoutedEventArgs e)
        {
            ShowItem.ItemsSource = null;
            Picker.IsEnabled = false;
            ////////////////////////////////////////////////////////////////////////////////////////
            ShowItem.ItemsSource = list;



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Picker.IsEnabled = false;
        }

        private void Picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowItem.ItemsSource = null;
            string SelectedDate = Picker.SelectedDate.ToString();
            var Filterlist = list.Where(s => s.Date == SelectedDate);
            ShowItem.ItemsSource = Filterlist;
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
