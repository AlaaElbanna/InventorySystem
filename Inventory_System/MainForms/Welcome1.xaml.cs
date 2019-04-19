using Inventory_System.Adding;
using Inventory_System.Connects;
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

namespace Final
{
    /// <summary>
    /// Interaction logic for Welcome1.xaml
    /// </summary>
    public partial class Welcome1 : Window
    {
        public Welcome1()
        {
            InitializeComponent();
        }
        public Welcome1(int code)
        {
            InitializeComponent();
            if (code == 0)
            {
                User.Visibility = Visibility.Visible;
            }
            else if (code == 1)
            {
                User.Visibility = Visibility.Collapsed;
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCategory add = new AddCategory();
            add.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem();
            add.Show();
            this.Close();
      
        }

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Billls bill = new Billls();
            bill.Show();
            this.Close();
      
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AddSalesMan add = new AddSalesMan();
            add.Show();
            this.Close();
      
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AddSupplier add = new AddSupplier();
            add.Show();
            this.Close();
      
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Reportss report = new Reportss();
            report.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            AddUser add = new AddUser();
            add.Show();
            this.Close();
     
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            AddCustomer add = new AddCustomer();
            add.Show();
            this.Close();
      
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
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
            AddUser add = new AddUser();
            add.Show();
            this.Close();

        }
    }
}
