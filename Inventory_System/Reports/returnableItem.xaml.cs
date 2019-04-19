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
    /// Interaction logic for returnableItem.xaml
    /// </summary>
    public partial class returnableItem : Window
    {
        ItemLayer item;
        List<ReturnData> Data;
        public returnableItem()
        {
            InitializeComponent();
            item = new ItemLayer();
            Data = new List<ReturnData>();
            Data = item.ReturnableItems();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Return.Items.Add("All");
            foreach (var item in Data)
            {

                if (!Return.Items.Contains(item.ItemName))
                    Return.Items.Add(item.ItemName);
            }
        }

        private void Return_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Return.SelectedIndex == -1)
                return;


            if (Return.SelectedItem.ToString() == "All")
            {
                ReturnData.Items.Clear();
                ReturnData.ItemsSource = Data;
            }
            else
            {
                ReturnData.ItemsSource = null;
                foreach (var item in Data)
                {
                    if (Return.SelectedItem.ToString() == item.ItemName)
                        ReturnData.Items.Add(item);
                    else
                        ReturnData.Items.Remove(item);
                }
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
