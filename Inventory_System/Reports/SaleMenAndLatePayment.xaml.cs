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
    /// Interaction logic for SaleMenAndLatePayment.xaml
    /// </summary>
    public partial class SaleMenAndLatePayment : Window
    {

        ItemLayer item;
        List<GetSaleManWithSales> getData;
        public SaleMenAndLatePayment()
        {
            InitializeComponent();
            item = new ItemLayer();
            getData = new List<GetSaleManWithSales>();
            getData = item.SaleMenAndLatePymant();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            foreach (var item in getData)
            {

                if (!comboSale.Items.Contains(item.SaleManName))
                    comboSale.Items.Add(item.SaleManName);
            }




        }

        private void All_Checked(object sender, RoutedEventArgs e)
        {
            SaleMan.Items.Clear();
            SaleMan.ItemsSource = getData;
            Picker.IsEnabled = false;
            comboSale.IsEnabled = false;

        }

        private void WithDate_Checked(object sender, RoutedEventArgs e)
        {
            Picker.IsEnabled = true;
            comboSale.IsEnabled = false;



        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SaleMan.ItemsSource = null;
            foreach (var item in getData)
            {
                if (item.LastDate.Contains(Picker.SelectedDate.ToString()))

                {
                    SaleMan.Items.Add(item);
                }
                else
                {
                    SaleMan.Items.Remove(item);
                }
            }
        }

        private void SaleName_Checked(object sender, RoutedEventArgs e)
        {

            comboSale.IsEnabled = true;
            Picker.IsEnabled = false;

        }

        private void comboSale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboSale.SelectedIndex == -1)
                return;

            SaleMan.ItemsSource = null;
            foreach (var item in getData)
            {
                if (item.SaleManName.Contains(comboSale.SelectedItem.ToString())
                    && !SaleMan.Items.Contains(item)
                    )
                {
                    SaleMan.Items.Add(item);
                }
                else if (!item.SaleManName.Contains(comboSale.SelectedItem.ToString()))
                {
                    SaleMan.Items.Remove(item);
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


