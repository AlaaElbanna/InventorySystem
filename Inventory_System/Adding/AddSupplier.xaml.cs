using Final;
using Inventory_System;
using Inventory_System.Connects;
using Inventory_System.EF_Classes;
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

namespace Inventory_System.Adding
{
    /// <summary>
    /// Interaction logic for AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Window
    {
        Context context;
        public AddSupplier()
        {
            InitializeComponent();
            context = new Context();
        }
        private void Button_Click10(object sender, RoutedEventArgs e)
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
            if (Name.Text != "" && Phone.Text != "" && Address.Text != "")
            {
                if (Regex.Match(Phone.Text, @"^([0-9]){11}").Success && Regex.Match(Name.Text, @"^[A-Za-z]+[\s][A-Za-z]+[\s][A-Za-z]+$").Success)
                {
                    Supplier sup = new Supplier()
                    {
                        Name = Name.Text,
                        Address = Address.Text,
                        Phone = Phone.Text
                    };

                    context.Suppliers.Add(sup);
                    context.SaveChanges();
                    MessageBox.Show("Supplier Added Successfully");
                }
                else
                {
                    MessageBox.Show("Enter Correct Phone Should Be 11 Number Or Third Name ");
                }
            }
            else
            {
                MessageBox.Show("Complete All Data");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
