using Final;
using Inventory_System.Adding;
using Inventory_System.Connects;
using Inventory_System.DataBaseLayers;
using Inventory_System.NotMappedCalsses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for SalesItem.xaml
    /// </summary>
    public partial class SalesItem : Window
    {
        ItemLayer item;
        List<SaleData> Data;
        double invest;
        public SalesItem()
        {
            InitializeComponent();
            item = new ItemLayer();
            Data = new List<SaleData>();
            Data = item.SalesItem();
        }

        private void All_Checked(object sender, RoutedEventArgs e)
        {
            Picker.IsEnabled = false;
            ItemName.IsEnabled = false;
            invest = 0;
            listView.Items.Clear();
            foreach (var item in Data)
            {
                invest += (   double.Parse(item.TotalPrice)-item.TotalSellPrice);
            }
            listView.ItemsSource = Data;
            Investment.Text = invest.ToString() + " EGY";
        }
        private void ByDate_Checked(object sender, RoutedEventArgs e)
        {
            Picker.IsEnabled = true;
            ItemName.IsEnabled = false;

        }

        private void Picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            listView.ItemsSource = null;
            invest = 0;
            foreach (var item in Data)
            {
                if (item.SaleDate.Contains(Picker.SelectedDate.ToString()))

                {
                    listView.Items.Add(item);
                    invest += (double.Parse(item.TotalPrice) - item.TotalSellPrice);

                }
                else
                {
                    listView.Items.Remove(item);
                }
            }
            Investment.Text = invest.ToString() + " EGY";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Data)
            {
                if (!ItemName.Items.Contains(item.ItemName))
                    ItemName.Items.Add(item.ItemName);
            }
        }

        private void ItemName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ItemName.SelectedIndex == -1)
                return;

            listView.ItemsSource = null;
            invest = 0;

            foreach (var item in Data)
            {
                if (item.ItemName.Contains(ItemName.SelectedItem.ToString())
                    && !listView.Items.Contains(item))
                {
                    listView.Items.Add(item);
                    invest += (double.Parse(item.TotalPrice) - item.TotalSellPrice);
                }
                else
                {
                    listView.Items.Remove(item);
                }
            }
            Investment.Text= invest.ToString() + " EGY";
        }

        private void ByItem_Checked(object sender, RoutedEventArgs e)
        {
            Picker.IsEnabled = false;
            ItemName.IsEnabled = true;
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
