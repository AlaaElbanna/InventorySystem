using Final;
using Inventory_System.Adding;
using Inventory_System.Connects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for LessQuantity.xaml
    /// </summary>
    public partial class LessQuantity : Window
    {
        Context context;
        public LessQuantity()
        {

            InitializeComponent();
            context = new Context();
            var query = context.Catogerys;
            CategoryCombo.SelectedValuePath = "ID";
            CategoryCombo.DisplayMemberPath = "Name";
            CategoryCombo.ItemsSource = query.ToList();


        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListView.Items.Clear();
            int result;
            if (!int.TryParse(QuantityText.Text , out result) )
            {

                MessageBox.Show("This Quantity is not Valid");
                return;
            }
            else if (result<0)
            {
                MessageBox.Show("This Quantity is Negative");
                return;

            }

            else if (All.IsChecked == true)
            {
                int qua = int.Parse(QuantityText.Text);
                var Items = context.Items.Where(t => t.Quantity < qua);
                foreach (var item in Items)
                {
                    ListView.Items.Add(item);
                }
            }
            else if (Special.IsChecked == true)
            {
                int cat_Id = int.Parse(CategoryCombo.SelectedValue.ToString());
                int Quantity = int.Parse(QuantityText.Text);
                var Items = context.Items.Where(t => t.Cat_Id == cat_Id && t.Quantity < Quantity);
                if (Items == null)
                {
                    MessageBox.Show("No Less Than This");
                    return;
                }

                foreach (var item in Items)
                {
                    ListView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Please select search");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void All_Checked(object sender, RoutedEventArgs e)
        {
            CategoryCombo.IsEnabled = false;
        }

        private void Special_Checked(object sender, RoutedEventArgs e)
        {
            CategoryCombo.IsEnabled = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
