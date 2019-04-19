using Inventory_System.EF_Classes;
using Inventory_System.Connects;
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
using Final;

namespace Inventory_System.Adding
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        Context context = new Context();
        public AddCategory()
        {
            InitializeComponent();
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

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            AddCustomer add = new AddCustomer();
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
            Login login = new Login();
            login.Show();
            this.Close();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void key_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.Key))
                e.Handled = true;

        }

        private void key_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            if (txtCat.Text != "")
            {
                Catogery c1 = new Catogery { Name = txtCat.Text };
                context.Catogerys.Add(c1);
                context.SaveChanges();
                MessageBox.Show("your object  inserted");
            }
            else
            {
                MessageBox.Show("plz insert data into textbox");
            }
        }

        
    }
}
